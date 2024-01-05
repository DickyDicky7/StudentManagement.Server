﻿namespace StudentManagement.Server
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
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                //options.CustomSchemaIds(type => type.FullName);
                //options.SchemaFilter<SchemaFilterOnCommonRequestVirtualProperty>();
            });

            builder.Services.AddDbContext<ApplicationDbContext>();
            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                options.SerializerOptions.Converters.Add(new DateOnlyJsonConverter());
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

            app.UseAuthorization();

            app.MapAPI_BangDiemHocPhan();
            app.MapAPI_BoMon();
            app.MapAPI_BuoiHoc();
            app.MapAPI_BuoiThi();
            app.MapAPI_ChuyenNganh();
            app.MapAPI_DanhSachDangKyHocPhan();
            //app.MapAPI_GiangVien();
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
            //app.MapAPI_MonHoc();
            app.MapAPI_MonHocThuocBoMon();
            app.MapAPI_MonHocThuocKhoaDaoTao();
            app.MapAPI_SinhVien();
            app.MapAPI_ThongTinDangKyHocPhan();
            app.MapAPI_ThongTinHocKyNamHoc();
            app.MapAPI_ThongTinHocPhi();

            app.Run();
        }

        public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
        {
            public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateOnly.FromDateTime(reader.GetDateTime());
            }

            public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            {
                string isoDate = value.ToString("O");
                writer.WriteStringValue(isoDate);
            }
        }
    }
}
