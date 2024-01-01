namespace StudentManagement.Server.API
{
    public static class API_ChuyenNganh
    {
        public static WebApplication MapAPI_ChuyenNganh(this WebApplication app)
        {
            app
                .MapPost(@"/chuyen-nganh/get-many", InternalMethods.ChuyenNganh_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ChuyenNganh>> ChuyenNganh_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ChuyenNganh reqBodyFilter)
            {
                ResBody_GetMany<ChuyenNganh> resBody_GetMany = new()
                {
                    Result = await context.ChuyenNganhs
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
