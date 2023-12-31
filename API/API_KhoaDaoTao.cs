namespace StudentManagement.Server.API
{
    public static class API_KhoaDaoTao
    {
        public static WebApplication MapAPI_KhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-dao-tao/get-many", InternalMethods.KhoaDaoTao_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<KhoaDaoTao>> KhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhoaDaoTao reqBody)
            {
                Common.ResBody<KhoaDaoTao> resBody = new()
                {
                    Result = await context.KhoaDaoTaos
                    .Where(khoaDaoTao => reqBody
                    .Match(khoaDaoTao))
                    .Skip(offset).Take(limit).ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
