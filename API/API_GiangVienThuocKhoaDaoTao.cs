namespace StudentManagement.Server.API
{
    public static class API_GiangVienThuocKhoaDaoTao
    {
        public static WebApplication MapAPI_GiangVienThuocKhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/giang-vien-thuoc-khoa-dao-tao/get-many", InternalMethods.GiangVienThuocKhoaDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVienThuocKhoaDaoTao>> GiangVienThuocKhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GiangVienThuocKhoaDaoTao reqBodyFilter)
            {
                ResBody_GetMany<GiangVienThuocKhoaDaoTao> resBody_GetMany = new()
                {
                    Result = await context.GiangVienThuocKhoaDaoTaos
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
