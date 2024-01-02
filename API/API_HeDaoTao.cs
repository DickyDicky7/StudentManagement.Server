namespace StudentManagement.Server.API
{
    public static class API_HeDaoTao
    {
        public static WebApplication MapAPI_HeDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/he-dao-tao/get-many", InternalMethods.HeDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/he-dao-tao/add-many", InternalMethods.HeDaoTao_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

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

            public static async Task<ResBody_AddMany<HeDaoTao>> HeDaoTao_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_HeDaoTao, HeDaoTao> reqBody_AddMany)
            {
                ResBody_AddMany<HeDaoTao> resBody_AddMany = new();
                IEnumerable    <HeDaoTao> heDaoTaos       = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.HeDaoTaos.AddRangeAsync(heDaoTaos);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = heDaoTaos
                        .Where (heDaoTao => heDaoTao.MaHeDaoTao != default)
                        .Select(heDaoTao => heDaoTao.MaHeDaoTao);
                }
                else
                {
                    resBody_AddMany.Result        = heDaoTaos
                        .Where (heDaoTao => heDaoTao.MaHeDaoTao != default);
                }
                return resBody_AddMany;
            }

        }
    }
}
