namespace StudentManagement.Server.API
{
    public static class API_KhoaDaoTao
    {
        public static WebApplication MapAPI_KhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-dao-tao/get-many", InternalMethods.KhoaDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/khoa-dao-tao/add-many", InternalMethods.KhoaDaoTao_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/khoa-dao-tao/remove-many", InternalMethods.KhoaDaoTao_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhoaDaoTao>> KhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_KhoaDaoTao, KhoaDaoTao> reqBody_GetMany)
            {
                ResBody_GetMany<KhoaDaoTao> resBody_GetMany = new()
                {
                    Result = await context.KhoaDaoTaos
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<KhoaDaoTao>> KhoaDaoTao_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KhoaDaoTao, KhoaDaoTao> reqBody_AddMany)
            {
                ResBody_AddMany<KhoaDaoTao> resBody_AddMany = new();
                IEnumerable    <KhoaDaoTao> khoaDaoTaos     = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.KhoaDaoTaos.AddRangeAsync(khoaDaoTaos);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds   =  khoaDaoTaos
                    .Where (khoaDaoTao => khoaDaoTao.MaKhoaDaoTao != default)
                    .Select(khoaDaoTao => khoaDaoTao.MaKhoaDaoTao);
                }
                else
                {
                    resBody_AddMany.Result          =  khoaDaoTaos
                    .Where (khoaDaoTao => khoaDaoTao.MaKhoaDaoTao != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<KhoaDaoTao>> KhoaDaoTao_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_KhoaDaoTao, KhoaDaoTao> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KhoaDaoTao> resBody_RemoveMany = new();
                IQueryable        <KhoaDaoTao> khoaDaoTaos        = context.KhoaDaoTaos.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = khoaDaoTaos
                    .Select(khoaDaoTao => khoaDaoTao.MaKhoaDaoTao);
                }
                else
                {
                    resBody_RemoveMany.Result        = khoaDaoTaos;
                }
                context.KhoaDaoTaos
                       .RemoveRange(khoaDaoTaos);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
