namespace StudentManagement.Server.API
{
    public static class API_SinhVien
    {
        public static WebApplication MapAPI_SinhVien(this WebApplication app)
        {
            app
                .MapPost(@"/sinh-vien/get-many", InternalMethods.SinhVien_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<SinhVien>> SinhVien_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_SinhVien reqBody)
            {
                Common.ResBody<SinhVien> resBody = new()
                {
                    Result = await context.SinhViens
                    .Where(sinhVien => reqBody
                    .Match(sinhVien))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
