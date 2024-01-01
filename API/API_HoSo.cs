namespace StudentManagement.Server.API
{
    public static class API_HoSo
    {
        public static WebApplication MapAPI_HoSo(this WebApplication app)
        {
            app
                .MapPost(@"/ho-so/get-many", InternalMethods.HoSo_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HoSo>> HoSo_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HoSo reqBodyFilter)
            {
                ResBody_GetMany<HoSo> resBody_GetMany = new()
                {
                    Result = await context.HoSos
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
