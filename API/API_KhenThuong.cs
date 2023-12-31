namespace StudentManagement.Server.API
{
    public static class API_KhenThuong
    {
        public static WebApplication MapAPI_KhenThuong(this WebApplication app)
        {
            app
                .MapPost(@"/khen-thuong/get-many", InternalMethods.KhenThuong_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<KhenThuong>> KhenThuong_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhenThuong reqBody)
            {
                Common.ResBody<KhenThuong> resBody = new()
                {
                    Result = await context.KhenThuongs
                    .Where(khenThuong => reqBody
                    .Match(khenThuong))
                    .Skip(offset).Take(limit).ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
