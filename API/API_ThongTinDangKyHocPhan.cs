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

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinDangKyHocPhan>> ThongTinDangKyHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinDangKyHocPhan reqBodyFilter)
            {
                ResBody_GetMany<ThongTinDangKyHocPhan> resBody_GetMany = new()
                {
                    Result = await context.ThongTinDangKyHocPhans
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }
        }
    }
}
