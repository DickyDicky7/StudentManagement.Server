namespace StudentManagement.Server.API
{
    public static class API_GiangVien
    {
        public static WebApplication MapAPI_GiangVien(this WebApplication app)
        {
            app
                .MapPost(@"/giang-vien/get-many", InternalMethods.GiangVien_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<GiangVien>> GiangVien_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GiangVien reqBody)
            {
                Common.ResBody<GiangVien> resBody = new()
                {
                    Result = await context.GiangViens
                    .Where(giangVien => reqBody
                    .Match(giangVien))
                    .Skip(offset).Take(limit).ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
