namespace StudentManagement.Server.API
{
    public static class API_HeDaoTao
    {
        public static WebApplication MapAPI_HeDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/he-dao-tao/get-many", InternalMethods.HeDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/he-dao-tao/add-many", InternalMethods.HeDaoTao_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/he-dao-tao/remove-many", InternalMethods.HeDaoTao_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HeDaoTao>> HeDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_HeDaoTao, HeDaoTao> reqBody_GetMany)
            {
                ResBody_GetMany<HeDaoTao> resBody_GetMany = new()
                {
                    Result = await context.HeDaoTaos
                    .Where(reqBody_GetMany.FilterBy
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

            public static async Task<ResBody_RemoveMany<HeDaoTao>> HeDaoTao_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_HeDaoTao, HeDaoTao> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<HeDaoTao> resBody_RemoveMany = new();
                IQueryable        <HeDaoTao> heDaoTaos          = context.HeDaoTaos.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = heDaoTaos
                    .Select(heDaoTao => heDaoTao.MaHeDaoTao);
                }
                else
                {
                    resBody_RemoveMany.Result        = heDaoTaos;
                }
                context.HeDaoTaos
                       .RemoveRange(heDaoTaos);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
