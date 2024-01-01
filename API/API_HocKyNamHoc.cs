namespace StudentManagement.Server.API
{
    public static class API_HocKyNamHoc
    {
        public static WebApplication MapAPI_HocKyNamHoc(this WebApplication app)
        {
            app
                .MapPost(@"/hoc-ky-nam-hoc/get-many", InternalMethods.HocKyNamHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HocKyNamHoc>> HocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HocKyNamHoc reqBodyFilter)
            {
                ResBody_GetMany<HocKyNamHoc> resBody_GetMany = new()
                {
                    Result = await context.HocKyNamHocs
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
