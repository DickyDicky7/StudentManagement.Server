﻿namespace StudentManagement.Server.API
{
    public static class API_Helper
    {
        public static WebApplication MapAPI_Helper(this WebApplication app)
        {
            app
                .MapGet("/tinh-trang-hoc-tap/get-all", () =>
                {
                    return new ResBody_Helper<List<string>>()
                    {
                        Result = new()
                        {
                            "đang học",
                            "thôi học", "tốt nghiệp", "bảo lưu kết quả", "đình chỉ học", },
                    };
                })
                .WithTags("Helper");

            return app;
        }
    }
}
