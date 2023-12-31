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

        private class InternalMethods
        {
            public static async Task<Common.ResBody<GiangVienThuocBoMon>> GiangVienThuocBoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GiangVienThuocBoMon reqBodyFilter)
            {
                Common.ResBody<GiangVienThuocBoMon> resBody = new()
                {
                    Result = await context.GiangVienThuocBoMons
                    .Where(reqBodyFilter
                    .MatchExpression(reqBodyFilter))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
