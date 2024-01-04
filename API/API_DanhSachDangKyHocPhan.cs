namespace StudentManagement.Server.API
{
    public static class API_DanhSachDangKyHocPhan
    {
        public static WebApplication MapAPI_DanhSachDangKyHocPhan(this WebApplication app)
        {
            app
                .MapPost (@"/danh-sach-dang-ky-hoc-phan/get-many", InternalMethods.DanhSachDangKyHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/danh-sach-dang-ky-hoc-phan/add-many", InternalMethods.DanhSachDangKyHocPhan_AddMany)
                .WithTags(@"Add many");

            app
                .MapPut   (@"/danh-sach-dang-ky-hoc-phan/update-many", InternalMethods.DanhSachDangKyHocPhan_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/danh-sach-dang-ky-hoc-phan/remove-many", InternalMethods.DanhSachDangKyHocPhan_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<DanhSachDangKyHocPhan>> DanhSachDangKyHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_DanhSachDangKyHocPhan,  DanhSachDangKyHocPhan> reqBody_GetMany)
            {
                ResBody_GetMany<DanhSachDangKyHocPhan> resBody_GetMany = new()
                {
                    Result = (
                    await context.DanhSachDangKyHocPhans
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           DanhSachDangKyHocPhan>>DanhSachDangKyHocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_DanhSachDangKyHocPhan, DanhSachDangKyHocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<DanhSachDangKyHocPhan> resBody_AddMany        = new();
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

            public static async Task<ResBody_UpdateMany<DanhSachDangKyHocPhan>> DanhSachDangKyHocPhan_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_DanhSachDangKyHocPhan,  DanhSachDangKyHocPhan> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<DanhSachDangKyHocPhan> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.DanhSachDangKyHocPhans.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long                 >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<DanhSachDangKyHocPhan>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<DanhSachDangKyHocPhan>> DanhSachDangKyHocPhan_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_DanhSachDangKyHocPhan,  DanhSachDangKyHocPhan> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<DanhSachDangKyHocPhan> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long                 >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<DanhSachDangKyHocPhan>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.DanhSachDangKyHocPhans.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
