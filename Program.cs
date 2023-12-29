using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Server.Database;

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
			builder.Services.AddAuthorization();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<ApplicationDbContext>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

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



			app.Run();
		}
	}
}
