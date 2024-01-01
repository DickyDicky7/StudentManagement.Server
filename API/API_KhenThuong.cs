namespace StudentManagement.Server.API
{
    public static class API_KhenThuong
    {
        public static WebApplication MapAPI_KhenThuong(this WebApplication app)
        {
            app
                .MapPost(@"/khen-thuong/get-many", InternalMethods.KhenThuong_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhenThuong>> KhenThuong_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhenThuong reqBodyFilter)
            {
                ResBody_GetMany<KhenThuong> resBody_GetMany = new()
                {
                    Result = await context.KhenThuongs
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
