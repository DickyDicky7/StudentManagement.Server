namespace StudentManagement.Server.API
{
    public static class API_MonHocThuocBoMon
    {
        public static WebApplication MapAPI_MonHocThuocBoMon(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc-thuoc-bo-mon/get-many", InternalMethods.MonHocThuocBoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/mon-hoc-thuoc-bo-mon/add-many", InternalMethods.MonHocThuocBoMon_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/mon-hoc-thuoc-bo-mon/remove-many", InternalMethods.MonHocThuocBoMon_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<MonHocThuocBoMon>> MonHocThuocBoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_MonHocThuocBoMon, MonHocThuocBoMon> reqBody_GetMany)
            {
                ResBody_GetMany<MonHocThuocBoMon> resBody_GetMany = new()
                {
                    Result = await context.MonHocThuocBoMons
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<MonHocThuocBoMon>> MonHocThuocBoMon_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_MonHocThuocBoMon, MonHocThuocBoMon> reqBody_AddMany)
            {
                ResBody_AddMany<MonHocThuocBoMon> resBody_AddMany   = new();
                IEnumerable    <MonHocThuocBoMon> monHocThuocBoMons = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.MonHocThuocBoMons.AddRangeAsync(monHocThuocBoMons);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = monHocThuocBoMons
                        .Where (monHocThuocBoMon => monHocThuocBoMon.MaMonHoc != default)
                        .Select(monHocThuocBoMon => monHocThuocBoMon.MaMonHoc);
                }
                else
                {
                    resBody_AddMany.Result        = monHocThuocBoMons
                        .Where (monHocThuocBoMon => monHocThuocBoMon.MaMonHoc != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<MonHocThuocBoMon>> MonHocThuocBoMon_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_MonHocThuocBoMon, MonHocThuocBoMon> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<MonHocThuocBoMon> resBody_RemoveMany = new();
                IQueryable        <MonHocThuocBoMon> monHocThuocBoMons  = context.MonHocThuocBoMons.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = monHocThuocBoMons
                    .Select(monHocThuocBoMon => monHocThuocBoMon.MaMonHoc);
                }
                else
                {
                    resBody_RemoveMany.Result        = monHocThuocBoMons;
                }
                context.MonHocThuocBoMons
                       .RemoveRange(monHocThuocBoMons);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
