namespace StudentManagement.Server.API
{
    public static class API_MonHocThuocBoMon
    {
        public static WebApplication MapAPI_MonHocThuocBoMon(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc-thuoc-bo-mon/get-many", InternalMethods.MonHocThuocBoMon_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<MonHocThuocBoMon>> MonHocThuocBoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_MonHocThuocBoMon reqBody)
            {
                Common.ResBody<MonHocThuocBoMon> resBody = new()
                {
                    Result = await context.MonHocThuocBoMons
                    .Where(monHocThuocBoMon => reqBody
                    .Match(monHocThuocBoMon))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
