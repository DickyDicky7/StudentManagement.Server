namespace StudentManagement.Server.API
{
    public static class API_DanhSachDangKyHocPhan
    {
        public static WebApplication MapAPI_DanhSachDangKyHocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/danh-sach-dang-ky-hoc-phan/get-many", InternalMethods.DanhSachDangKyHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/danh-sach-dang-ky-hoc-phan/add-many", InternalMethods.DanhSachDangKyHocPhan_AddMany)
                .WithTags(@"Add many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<DanhSachDangKyHocPhan>> DanhSachDangKyHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_DanhSachDangKyHocPhan reqBodyFilter)
            {
                ResBody_GetMany<DanhSachDangKyHocPhan> resBody_GetMany = new()
                {
                    Result = (
                    await context.DanhSachDangKyHocPhans
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<DanhSachDangKyHocPhan>> DanhSachDangKyHocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_DanhSachDangKyHocPhan, DanhSachDangKyHocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<DanhSachDangKyHocPhan> resBody_AddMany  = new();
                IEnumerable    <DanhSachDangKyHocPhan> danhSachDangKyHocPhans = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.DanhSachDangKyHocPhans.AddRangeAsync(danhSachDangKyHocPhans);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                //if (reqBody_AddMany.ReturnJustIds)
                //{
                //    resBody_AddMany.ResultJustIds = danhSachDangKyHocPhans
                //        .Where (danhSachDangKyHocPhan => danhSachDangKyHocPhan.MaDanhSachDangKyHocPhan != default)
                //        .Select(danhSachDangKyHocPhan => danhSachDangKyHocPhan.MaDanhSachDangKyHocPhan);
                //}
                //else
                //{
                //    resBody_AddMany.Result        = danhSachDangKyHocPhans
                //        .Where (danhSachDangKyHocPhan => danhSachDangKyHocPhan.MaDanhSachDangKyHocPhan != default);
                //}
                return resBody_AddMany;
            }
        }
    }
}
