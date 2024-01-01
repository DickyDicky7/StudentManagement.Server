namespace StudentManagement.Server.API
{
    public static class API_BoMon
    {
        public static WebApplication MapAPI_BoMon(this WebApplication app)
        {
            app
                .MapPost(@"/bo-mon/get-many", InternalMethods.BoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BoMon>> BoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BoMon reqBodyFilter)
            {
                ResBody_GetMany<BoMon> resBody_GetMany = new()
                {
                    Result = await context.BoMons
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
