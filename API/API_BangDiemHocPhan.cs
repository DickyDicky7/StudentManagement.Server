namespace StudentManagement.Server.API
{
    public static class API_BangDiemHocPhan
    {
        public static WebApplication MapAPI_BangDiemHocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/bang-diem-hoc-phan/get-many", InternalMethods.BangDiemHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app.MapPost(@"/bang-diem-hoc-phan/add-many", InternalMethods.BangDiemHocPhan_AddMany);

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BangDiemHocPhan>> BangDiemHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BangDiemHocPhan reqBodyFilter)
            {
                ResBody_GetMany<BangDiemHocPhan> resBody_GetMany = new()
                {
                    Result = (
                    await context.BangDiemHocPhans
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<BangDiemHocPhan>> BangDiemHocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<ReqBody_BangDiemHocPhan, BangDiemHocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<BangDiemHocPhan> resBody_AddMany = new();
                
                return resBody_AddMany;
            }
        }
    }
}
