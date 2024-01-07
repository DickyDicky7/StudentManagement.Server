using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.VisualStudio.TextTemplating;
using System.IdentityModel.Tokens.Jwt;
using StudentManagement.Server.Database;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Net.WebSockets;

namespace StudentManagement.Server.API
{
    public static class API_Authen
    {
        public static WebApplication MapAPI_Authentication(this WebApplication app)
        {
            app.MapPost("/login", InternalMethods.LogInHandler).AllowAnonymous();
            app.MapPost("/refresh", InternalMethods.RefreshTokenHandler);
            app.MapDelete("/logout", InternalMethods.LogOutHandler);
            return app;
        }
        private static class InternalMethods
        {
            public static async Task<IResult> LogInHandler(
                [FromServices] ApplicationDbContext context,
                [FromServices] IConfiguration configuration,
                [FromQuery(Name = "username")] string username,
                [FromQuery(Name = "password")] string password,
                [FromQuery(Name = "role")] string role)
            {
                if (string.IsNullOrEmpty(username))
                {
                    return Results.BadRequest("Username is empty");
                }
                else if (string.IsNullOrEmpty(password))
                {
                    return Results.BadRequest("Password is empty");
                }
                if (role == "sv")
                {
                    SinhVien? sinhVien = await context.SinhViens.FirstOrDefaultAsync(sinhVien => sinhVien.Username == username);
                    if (sinhVien == null)
                    {
                        return Results.BadRequest("User does not exists");
                    }
                    else if (password != sinhVien.UsernamePassword)
                    {
                        return Results.Unauthorized();
                    }
                    else
                    {
						List<Claim> claimList = new List<Claim>()
						{
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.Role, role),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };
                        var accessToken = GenerateAccessToken(configuration, claimList);
                        var refreshToken = GenerateRefreshToken(configuration);
                        await context.JwtStorages.AddAsync(new JwtStorage()
                        {
                            MaSinhVienHoacNhanVien = sinhVien.MaSinhVien,
                            Loai = "sv",
                            AccessToken = accessToken,
                            RefreshToken = refreshToken
                        });
                        await context.SaveChangesAsync();
                        return Results.Ok(new
                        {
                            AccessToken = accessToken,
                            RefreshToken = refreshToken
                        });
                    }
                }
                else
                {
                    NhanVien? nhanVien = await context.NhanViens.FirstOrDefaultAsync(nhanVien => nhanVien.Username == username);
                    if (nhanVien == null)
                    {
                        return Results.BadRequest("User does not exists");
                    }
                    else if (password != nhanVien.UsernamePassword)
                    {
                        return Results.Unauthorized();
                    }
                    else
                    {
                        List<Claim> claimList = new List<Claim>()
                        {
							new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.Role, role),
							new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
						};
                        var accessToken = GenerateAccessToken(configuration, claimList);
                        var refreshToken = GenerateRefreshToken(configuration);
                        await context.JwtStorages.AddAsync(new JwtStorage()
                        {
                            MaSinhVienHoacNhanVien = nhanVien.MaNhanVien,
                            Loai = "nv",
                            AccessToken = accessToken,
                            RefreshToken = refreshToken
                        });
                        await context.SaveChangesAsync();
                        return Results.Ok(new
                        {
                            Token = accessToken,
                            RefreshToken = refreshToken
                        });
                    }
                }
                
            }
            public static async Task<IResult> RefreshTokenHandler(
                [FromServices] ApplicationDbContext context,
                [FromServices] IConfiguration configuration,
                [FromQuery(Name = "accessToken")] string accessToken,
                [FromQuery(Name = "refreshToken")] string refreshToken)
            {
                if (accessToken == null || refreshToken == null)
                {
                    return Results.BadRequest("Invalid client request");
                }
                ClaimsPrincipal? principal = GetPrincipalFromToken(accessToken, configuration);
                if (principal == null)
                {
                    return Results.BadRequest("Invalid access token or refresh token");
                }
                string username = principal.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
                string role = principal.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
                long id;
                if (role == "sv")
                {
                    id = context.SinhViens.First(sinhVien => sinhVien.Username == username).MaSinhVien;
                }
                else
                {
                    id = context.NhanViens.First(nhanVien => nhanVien.Username == username).MaNhanVien;
                }
                JwtStorage user = await context.JwtStorages.FirstAsync(user => (user.MaSinhVienHoacNhanVien == id && user.Loai == role));
                if (user == null || user.RefreshToken != refreshToken)
                {
                    return Results.BadRequest("Invalid access token or refresh token");
                }
                if (GetTokenExpiryTime(refreshToken) <= DateTime.Now)
                {
                    context.JwtStorages.Remove(user);
                    return Results.Unauthorized();
                }
                string newAccessToken = GenerateAccessToken(configuration, principal.Claims.ToList());
                user.AccessToken = newAccessToken;
                context.JwtStorages.Update(user);
                await context.SaveChangesAsync();
				return Results.Ok(new
                {
                    Token = newAccessToken
                });
            }
            public static async Task<IResult> LogOutHandler(
				[FromServices] ApplicationDbContext context,
				[FromServices] IConfiguration configuration,
				[FromQuery(Name = "accessToken")] string accessToken)
            {
                if (accessToken == null)
                {
                    return Results.BadRequest("Invalid client request");
                }
				ClaimsPrincipal? principal = GetPrincipalFromToken(accessToken, configuration);
				if (principal == null)
				{
					return Results.BadRequest("Invalid access token");
				}
				string username = principal.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
				string role = principal.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
				long id;
				if (role == "sv")
				{
					id = context.SinhViens.First(sinhVien => sinhVien.Username == username).MaSinhVien;
				}
				else
				{
					id = context.NhanViens.First(nhanVien => nhanVien.Username == username).MaNhanVien;
				}
				JwtStorage user = await context.JwtStorages.FirstAsync(user => (user.MaSinhVienHoacNhanVien == id && user.Loai == role));
                context.JwtStorages.Remove(user);
                await context.SaveChangesAsync();
                return Results.Ok();
            }
            public static string GenerateAccessToken(IConfiguration configuration, List<Claim> claims)
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            public static string GenerateRefreshToken(IConfiguration configuration)
            {
				var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, "refresh_token"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64)
                    }),
                    Expires = DateTime.UtcNow.AddHours(3),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
				var tokenHandler = new JwtSecurityTokenHandler();
				var token = tokenHandler.CreateToken(tokenDescriptor);
				return tokenHandler.WriteToken(token);
			}
            public static ClaimsPrincipal? GetPrincipalFromToken(
                string? token,
                IConfiguration configuration)
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                //if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                //    throw new SecurityTokenException("Invalid token");
                return principal;
            }
            public static DateTime GetTokenExpiryTime(string token)
            {
				var tokenHandler = new JwtSecurityTokenHandler();

				if (tokenHandler.CanReadToken(token))
				{
					var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

					if (jwtToken != null)
					{
						// Check if the token has an expiration claim
						if (jwtToken.Payload.TryGetValue(JwtRegisteredClaimNames.Exp, out var expValue) &&
							expValue is long expUnix)
						{
							// Convert expiration time from Unix timestamp to DateTime
							return DateTimeOffset.FromUnixTimeSeconds(expUnix).DateTime;
						}
					}
				}

                // Token is not valid or does not contain expiration information
                return DateTime.MinValue;
			}
        }
    }
}
