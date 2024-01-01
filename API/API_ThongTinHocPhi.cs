namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocPhi
    {
        public static WebApplication MapAPI_ThongTinHocPhi(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-hoc-phi/get-many", InternalMethods.ThongTinHocPhi_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinHocPhi>> ThongTinHocPhi_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinHocPhi reqBodyFilter)
            {
                ResBody_GetMany<ThongTinHocPhi> resBody_GetMany = new()
                {
                    Result = await context.ThongTinHocPhis
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
