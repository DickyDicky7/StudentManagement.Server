namespace StudentManagement.Server.API
{
    public static class API_GiangVien
    {
        public static WebApplication MapAPI_GiangVien(this WebApplication app)
        {
            app
                .MapPost(@"/giang-vien/get-many", InternalMethods.GiangVien_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVien>> GiangVien_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GiangVien reqBodyFilter)
            {
                ResBody_GetMany<GiangVien> resBody_GetMany = new()
                {
                    Result = await context.GiangViens
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
