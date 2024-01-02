namespace StudentManagement.Server.API
{
    public static class API_MonHocThuocBoMon
    {
        public static WebApplication MapAPI_MonHocThuocBoMon(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc-thuoc-bo-mon/get-many", InternalMethods.MonHocThuocBoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/mon-hoc-thuoc-bo-mon/add-many", InternalMethods.MonHocThuocBoMon_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<MonHocThuocBoMon>> MonHocThuocBoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_MonHocThuocBoMon reqBodyFilter)
            {
                ResBody_GetMany<MonHocThuocBoMon> resBody_GetMany = new()
                {
                    Result = await context.MonHocThuocBoMons
                    .Where(reqBodyFilter
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

        }
    }
}
