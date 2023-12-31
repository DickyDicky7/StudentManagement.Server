namespace StudentManagement.Server.API
{
    public static class API_KhoaHoc
    {
        public static WebApplication MapAPI_KhoaHoc(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-hoc/get-many", InternalMethods.KhoaHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<KhoaHoc>> KhoaHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhoaHoc reqBody)
            {
                Common.ResBody<KhoaHoc> resBody = new()
                {
                    Result = await context.KhoaHocs
                    .Where(khoaHoc => reqBody.Match(khoaHoc))
                    .Skip(offset).Take(limit).ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
