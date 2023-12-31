﻿namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocPhi
    {
        public static WebApplication MapAPI_ThongTinHocPhi(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-hoc-phi/get-many", InternalMethods.ThongTinHocPhi_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<ThongTinHocPhi>> ThongTinHocPhi_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinHocPhi reqBody)
            {
                Common.ResBody<ThongTinHocPhi> resBody = new()
                {
                    Result = await context.ThongTinHocPhis
                    .Where(thongTinHocPhi => reqBody
                    .Match(thongTinHocPhi))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
