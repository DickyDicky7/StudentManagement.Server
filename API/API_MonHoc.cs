namespace StudentManagement.Server.API
{
    public static class API_MonHoc
    {
        public static WebApplication MapAPI_MonHoc(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc/get-many", InternalMethods.MonHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<MonHoc>> MonHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_MonHoc reqBody)
            {
                Common.ResBody<MonHoc> resBody = new()
                {
                    Result = (await context.MonHocs
                    .Where(monHoc => reqBody
                    .Match(monHoc))
                    .Skip(offset).Take(limit)
                    .ToListAsync()),
                };
                return resBody;
            }
        }
    }
}
