namespace StudentManagement.Server.API
{
    public static class API_KhoaDaoTao
    {
        public static WebApplication MapAPI_KhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-dao-tao/get-many", InternalMethods.KhoaDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/khoa-dao-tao/add-many", InternalMethods.KhoaDaoTao_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

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

        }
    }
}
