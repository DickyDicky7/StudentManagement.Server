namespace StudentManagement.Server.API
{
    public static class API_GiangVienThuocBoMon
    {
        public static WebApplication MapAPI_GiangVienThuocBoMon(this WebApplication app)
        {
            app
                .MapPost(@"/giang-vien-thuoc-bo-mon/get-many", InternalMethods.GiangVienThuocBoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

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
        }
    }
}
