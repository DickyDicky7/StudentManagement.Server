namespace StudentManagement.Server.API
{
    public static class API_BangDiemHocPhan
    {
        public static WebApplication MapAPI_BangDiemHocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/bang-diem-hoc-phan/get-many", InternalMethods.BangDiemHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<Common.ResBody<BangDiemHocPhan>> BangDiemHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BangDiemHocPhan reqBodyFilter)
            {
                Common.ResBody<BangDiemHocPhan> resBody = new()
                {
                    Result = (
                    await context.BangDiemHocPhans
                    .Where(reqBodyFilter
                    .MatchExpression(reqBodyFilter))
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody;
            }
        }
    }
}
