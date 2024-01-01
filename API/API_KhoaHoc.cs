namespace StudentManagement.Server.API
{
    public static class API_KhoaHoc
    {
        public static WebApplication MapAPI_KhoaHoc(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-hoc/get-many", InternalMethods.KhoaHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhoaHoc>> KhoaHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhoaHoc reqBodyFilter)
            {
                ResBody_GetMany<KhoaHoc> resBody_GetMany = new()
                {
                    Result = await context.KhoaHocs
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
