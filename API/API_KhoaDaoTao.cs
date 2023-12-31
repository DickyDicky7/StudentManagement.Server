namespace StudentManagement.Server.API
{
    public static class API_KhoaDaoTao
    {
        public static WebApplication MapAPI_KhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-dao-tao/get-many", InternalMethods.KhoaDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<KhoaDaoTao>> KhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhoaDaoTao reqBodyFilter)
            {
                Common.ResBody<KhoaDaoTao> resBody = new()
                {
                    Result = await context.KhoaDaoTaos
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
