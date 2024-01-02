namespace StudentManagement.Server.API
{
    public static class API_ThongTinDangKyHocPhan
    {
        public static WebApplication MapAPI_ThongTinDangKyHocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-dang-ky-hoc-phan/get-many", InternalMethods.ThongTinDangKyHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/thong-tin-dang-ky-hoc-phan/add-many", InternalMethods.ThongTinDangKyHocPhan_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/thong-tin-dang-ky-hoc-phan/remove-many", InternalMethods.ThongTinDangKyHocPhan_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinDangKyHocPhan>> ThongTinDangKyHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_ThongTinDangKyHocPhan, ThongTinDangKyHocPhan> reqBody_GetMany)
            {
                ResBody_GetMany<ThongTinDangKyHocPhan> resBody_GetMany = new()
                {
                    Result = await context.ThongTinDangKyHocPhans
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<ThongTinDangKyHocPhan>> ThongTinDangKyHocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ThongTinDangKyHocPhan, ThongTinDangKyHocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<ThongTinDangKyHocPhan> resBody_AddMany        = new();
                IEnumerable    <ThongTinDangKyHocPhan> thongTinDangKyHocPhans = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.ThongTinDangKyHocPhans.AddRangeAsync(thongTinDangKyHocPhans);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = thongTinDangKyHocPhans
                        .Where (thongTinDangKyHocPhan => thongTinDangKyHocPhan.MaThongTinDangKyHocPhan != default)
                        .Select(thongTinDangKyHocPhan => thongTinDangKyHocPhan.MaThongTinDangKyHocPhan);
                }
                else
                {
                    resBody_AddMany.Result        = thongTinDangKyHocPhans
                        .Where (thongTinDangKyHocPhan => thongTinDangKyHocPhan.MaThongTinDangKyHocPhan != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<ThongTinDangKyHocPhan>> ThongTinDangKyHocPhan_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_ThongTinDangKyHocPhan, ThongTinDangKyHocPhan> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<ThongTinDangKyHocPhan> resBody_RemoveMany     = new();
                IQueryable        <ThongTinDangKyHocPhan> thongTinDangKyHocPhans = context.ThongTinDangKyHocPhans.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = thongTinDangKyHocPhans
                    .Select(thongTinDangKyHocPhan => thongTinDangKyHocPhan.MaThongTinDangKyHocPhan);
                }
                else
                {
                    resBody_RemoveMany.Result        = thongTinDangKyHocPhans;
                }
                context.ThongTinDangKyHocPhans
                       .RemoveRange(thongTinDangKyHocPhans);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
