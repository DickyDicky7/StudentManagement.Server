using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Server.API;
using StudentManagement.Server.Database;
using System.Text;

namespace StudentManagement.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            {
                string PORT = Environment.GetEnvironmentVariable("PORT")!;
                builder.WebHost.UseUrls($"http://0.0.0.0:{PORT}");
            }

            // Add services to the container.
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true
                    };
                });
            builder.Services.AddMvc();
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                //options.CustomSchemaIds(type => type.FullName);
                //options.SchemaFilter<SchemaFilterOnCommonRequestVirtualProperty>();
            });

            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy
                (policy =>
                {
                    policy.SetIsOriginAllowed(origin =>
                    origin == "http://localhost:3000").
                    AllowCredentials().
                    AllowAnyHeader().
                    AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                    options.DefaultModelExpandDepth(3);
                });
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapAPI_Authentication();
            app.MapAPI_File();
            app.MapAPI_Helper();
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/test", async ([FromServices] ApplicationDbContext context) =>
            {
                foreach (var item in await context.MonHocThuocBoMons.ToListAsync())
                {
                    System.Diagnostics.Debug.WriteLine(item.BoMon.TenBoMon);
                }
            });

            app.MapGet("/add", async ([FromServices] ApplicationDbContext context) =>
            {
                await context.AddAsync<MonHocThuocBoMon>(new()
                {
                    MaBoMon = 2,
                    TenMonHoc = "Đại Số Tuyến Tính",
                    ConMoLop = true,
                    LoaiMonHoc = "Đại Trà",
                    DanhSachMaMonHocTienQuyet = Array.Empty<string>(),
                    SoTinChiLyThuyet = 4,
                    SoTinChiThucHanh = 0,
                    TomTatMonHoc = "Mon học rất bổ ích"
                });

                await context.SaveChangesAsync();
            });

            app.MapGet("/thong-tin-hoc-ky-nam-hoc", async ([FromServices] ApplicationDbContext context) =>
            {
                return await context.ThongTinHocKyNamHocs.FirstAsync(thongTinHocKyNamHoc => true);
            });

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");
            app.MapGet("login/test", () => "Hello world").RequireAuthorization();


            app.MapAPI_Authentication();
            app.MapAPI_BangDiemHocPhan();
            app.MapAPI_BoMon();
            app.MapAPI_BuoiHoc();
            app.MapAPI_BuoiThi();
            app.MapAPI_ChuyenNganh();
            app.MapAPI_DanhSachDangKyHocPhan();
            app.MapAPI_GiangVien();
            app.MapAPI_GiangVienThuocBoMon();
            app.MapAPI_GiangVienThuocKhoaDaoTao();
            app.MapAPI_HeDaoTao();
            app.MapAPI_HocKyNamHoc();
            app.MapAPI_HocPhan();
            app.MapAPI_HoSo();
            app.MapAPI_KetQuaHocTap();
            app.MapAPI_KetQuaRenLuyen();
            app.MapAPI_KhenThuong();
            app.MapAPI_KhoaDaoTao();
            app.MapAPI_KhoaHoc();
            app.MapAPI_MonHoc();
            app.MapAPI_MonHocThuocBoMon();
            app.MapAPI_MonHocThuocKhoaDaoTao();
            app.MapAPI_SinhVien();
            app.MapAPI_ThongTinDangKyHocPhan();
            app.MapAPI_ThongTinHocKyNamHoc();
            app.MapAPI_ThongTinHocPhi();

            app.Run();
        }
    }
}

//