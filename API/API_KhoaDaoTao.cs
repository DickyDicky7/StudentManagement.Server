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

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhoaDaoTao>> KhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhoaDaoTao reqBodyFilter)
            {
                ResBody_GetMany<KhoaDaoTao> resBody_GetMany = new()
                {
                    Result = await context.KhoaDaoTaos
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
