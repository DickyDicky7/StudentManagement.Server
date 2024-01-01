namespace StudentManagement.Server.API
{
    public static class API_HeDaoTao
    {
        public static WebApplication MapAPI_HeDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/he-dao-tao/get-many", InternalMethods.HeDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HeDaoTao>> HeDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HeDaoTao reqBodyFilter)
            {
                ResBody_GetMany<HeDaoTao> resBody_GetMany = new()
                {
                    Result = await context.HeDaoTaos
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
