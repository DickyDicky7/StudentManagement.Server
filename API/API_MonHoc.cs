namespace StudentManagement.Server.API
{
    public static class API_MonHoc
    {
        public static WebApplication MapAPI_MonHoc(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc/get-many", InternalMethods.MonHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<MonHoc>> MonHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_MonHoc reqBodyFilter)
            {
                ResBody_GetMany<MonHoc> resBody_GetMany = new()
                {
                    Result = (await context.MonHocs
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()),
                };
                return resBody_GetMany;
            }
        }
    }
}
