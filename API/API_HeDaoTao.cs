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

        private class InternalMethods
        {
            public static async Task<Common.ResBody<HeDaoTao>> HeDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HeDaoTao reqBodyFilter)
            {
                Common.ResBody<HeDaoTao> resBody = new()
                {
                    Result = await context.HeDaoTaos
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
