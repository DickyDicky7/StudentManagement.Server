﻿namespace StudentManagement.Server.API
{
    public static class API_SinhVien
    {
        public static WebApplication MapAPI_SinhVien(this WebApplication app)
        {
            app
                .MapPost(@"/sinh-vien/get-many", InternalMethods.SinhVien_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<SinhVien>> SinhVien_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_SinhVien reqBodyFilter)
            {
                ResBody_GetMany<SinhVien> resBody_GetMany = new()
                {
                    Result = await context.SinhViens
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }
        }
    }
}
