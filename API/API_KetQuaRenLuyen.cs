namespace StudentManagement.Server.API
{
    public static class API_KetQuaRenLuyen
    {
        public static WebApplication MapAPI_KetQuaRenLuyen(this WebApplication app)
        {
            app
                .MapPost(@"/ket-qua-ren-luyen/get-many", InternalMethods.KetQuaRenLuyen_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaRenLuyen>> KetQuaRenLuyen_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KetQuaRenLuyen reqBodyFilter)
            {
                ResBody_GetMany<KetQuaRenLuyen> resBody_GetMany = new()
                {
                    Result = await context.KetQuaRenLuyens
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
