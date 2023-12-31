namespace StudentManagement.Server.API
{
    public static class API_ThongTinDangKyHocPhan
    {
        public static WebApplication MapAPI_ThongTinDangKyHocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-dang-ky-hoc-phan/get-many", InternalMethods.ThongTinDangKyHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<ThongTinDangKyHocPhan>> ThongTinDangKyHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinDangKyHocPhan reqBody)
            {
                Common.ResBody<ThongTinDangKyHocPhan> resBody = new()
                {
                    Result = await context.ThongTinDangKyHocPhans
                    .Where(thongTinDangKyHocPhan => reqBody
                    .Match(thongTinDangKyHocPhan))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
