namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocKyNamHoc
    {
        public static WebApplication MapAPI_ThongTinHocKyNamHoc(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-hoc-ky-nam-hoc/get-many", InternalMethods.ThongTinHocKyNamHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinHocKyNamHoc reqBodyFilter)
            {
                Common.ResBody<ThongTinHocKyNamHoc> resBody = new()
                {
                    Result = await context.ThongTinHocKyNamHocs
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
