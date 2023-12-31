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

        private class InternalMethods
        {
            public static async Task<Common.ResBody<HocKyNamHoc>> HocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HocKyNamHoc reqBody)
            {
                Common.ResBody<HocKyNamHoc> resBody = new()
                {
                    Result = await context.HocKyNamHocs
                    .Where(reqBody
                    .MatchExpression(reqBody))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }

        }
    }
}
