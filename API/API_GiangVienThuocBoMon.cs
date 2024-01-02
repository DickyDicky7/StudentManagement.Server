namespace StudentManagement.Server.API
{
    public static class API_GiangVienThuocBoMon
    {
        public static WebApplication MapAPI_GiangVienThuocBoMon(this WebApplication app)
        {
            app
                .MapPost(@"/giang-vien-thuoc-bo-mon/get-many", InternalMethods.GiangVienThuocBoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/giang-vien-thuoc-bo-mon/add-many", InternalMethods.GiangVienThuocBoMon_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVienThuocBoMon>> GiangVienThuocBoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GiangVienThuocBoMon reqBodyFilter)
            {
                ResBody_GetMany<GiangVienThuocBoMon> resBody_GetMany = new()
                {
                    Result = await context.GiangVienThuocBoMons
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<GiangVienThuocBoMon>> GiangVienThuocBoMon_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_GiangVienThuocBoMon, GiangVienThuocBoMon> reqBody_AddMany)
            {
                ResBody_AddMany<GiangVienThuocBoMon> resBody_AddMany      = new();
                IEnumerable    <GiangVienThuocBoMon> giangVienThuocBoMons = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.GiangVienThuocBoMons.AddRangeAsync(giangVienThuocBoMons);
                resBody_AddMany.NumberOfRowsAffected  = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = giangVienThuocBoMons
                    .Where (giangVienThuocBoMon  => giangVienThuocBoMon.MaGiangVien != default)
                    .Select(giangVienThuocBoMon  => giangVienThuocBoMon.MaGiangVien);
                }
                else
                {
                    resBody_AddMany.Result        = giangVienThuocBoMons
                    .Where (giangVienThuocBoMon  => giangVienThuocBoMon.MaGiangVien != default);
                }
                return resBody_AddMany;
            }

        }
    }
}
