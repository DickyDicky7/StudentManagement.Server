namespace StudentManagement.Server.API
{
    public static class API_HocPhan
    {
        public static WebApplication MapAPI_HocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/hoc-phan/get-many", InternalMethods.HocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<HocPhan>> HocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HocPhan reqBodyFilter)
            {
                Common.ResBody<HocPhan> resBody = new()
                {
                    Result = await context.HocPhans
                    .Where(reqBodyFilter
                    .MatchExpression(reqBodyFilter))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
