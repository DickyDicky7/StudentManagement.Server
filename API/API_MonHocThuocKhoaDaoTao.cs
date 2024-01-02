namespace StudentManagement.Server.API
{
    public static class API_MonHocThuocKhoaDaoTao
    {
        public static WebApplication MapAPI_MonHocThuocKhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc-thuoc-khoa-dao-tao/get-many", InternalMethods.MonHocThuocKhoaDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/mon-hoc-thuoc-khoa-dao-tao/add-many", InternalMethods.MonHocThuocKhoaDaoTao_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/mon-hoc-thuoc-khoa-dao-tao/remove-many", InternalMethods.MonHocThuocKhoaDaoTao_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<MonHocThuocKhoaDaoTao>> MonHocThuocKhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_MonHocThuocKhoaDaoTao, MonHocThuocKhoaDaoTao> reqBody_GetMany)
            {
                ResBody_GetMany<MonHocThuocKhoaDaoTao> resBody_GetMany = new()
                {
                    Result = (
                    await context.MonHocThuocKhoaDaoTaos
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<MonHocThuocKhoaDaoTao>> MonHocThuocKhoaDaoTao_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_MonHocThuocKhoaDaoTao, MonHocThuocKhoaDaoTao> reqBody_AddMany)
            {
                ResBody_AddMany<MonHocThuocKhoaDaoTao> resBody_AddMany  = new();
                IEnumerable    <MonHocThuocKhoaDaoTao> monHocThuocKhoaDaoTaos = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.MonHocThuocKhoaDaoTaos.AddRangeAsync(monHocThuocKhoaDaoTaos);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = monHocThuocKhoaDaoTaos
                        .Where (monHocThuocKhoaDaoTao => monHocThuocKhoaDaoTao.MaMonHoc != default)
                        .Select(monHocThuocKhoaDaoTao => monHocThuocKhoaDaoTao.MaMonHoc);
                }
                else
                {
                    resBody_AddMany.Result        = monHocThuocKhoaDaoTaos
                        .Where (monHocThuocKhoaDaoTao => monHocThuocKhoaDaoTao.MaMonHoc != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<MonHocThuocKhoaDaoTao>> MonHocThuocKhoaDaoTao_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_MonHocThuocKhoaDaoTao, MonHocThuocKhoaDaoTao> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<MonHocThuocKhoaDaoTao> resBody_RemoveMany     = new();
                IQueryable        <MonHocThuocKhoaDaoTao> monHocThuocKhoaDaoTaos = context.MonHocThuocKhoaDaoTaos.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = monHocThuocKhoaDaoTaos
                    .Select(monHocThuocKhoaDaoTao => monHocThuocKhoaDaoTao.MaMonHoc);
                }
                else
                {
                    resBody_RemoveMany.Result        = monHocThuocKhoaDaoTaos;
                }
                context.MonHocThuocKhoaDaoTaos
                       .RemoveRange(monHocThuocKhoaDaoTaos);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
