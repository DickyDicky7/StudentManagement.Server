namespace StudentManagement.Server.API
{
    public static class API_KetQuaHocTap
    {
        public static WebApplication MapAPI_KetQuaHocTap(this WebApplication app)
        {
            app
                .MapPost(@"/ket-qua-hoc-tap/get-many", InternalMethods.KetQuaHocTap_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<KetQuaHocTap>> KetQuaHocTap_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KetQuaHocTap reqBody)
            {
                Common.ResBody<KetQuaHocTap> resBody = new()
                {
                    Result = await context.KetQuaHocTaps
                    .Where(ketQuaHocTap => reqBody
                    .Match(ketQuaHocTap))
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
