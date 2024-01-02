namespace StudentManagement.Server.API
{
    public static class API_ChuyenNganh
    {
        public static WebApplication MapAPI_ChuyenNganh(this WebApplication app)
        {
            app
                .MapPost(@"/chuyen-nganh/get-many", InternalMethods.ChuyenNganh_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/chuyen-nganh/add-many", InternalMethods.ChuyenNganh_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

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

            public static async Task<ResBody_AddMany<ChuyenNganh>> ChuyenNganh_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ChuyenNganh, ChuyenNganh> reqBody_AddMany)
            {
                ResBody_AddMany<ChuyenNganh> resBody_AddMany = new();
                IEnumerable    <ChuyenNganh> chuyenNganhs    = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.ChuyenNganhs.AddRangeAsync(chuyenNganhs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = chuyenNganhs
                        .Where (chuyenNganh => chuyenNganh.MaChuyenNganh != default)
                        .Select(chuyenNganh => chuyenNganh.MaChuyenNganh);
                }
                else
                {
                    resBody_AddMany.Result        = chuyenNganhs
                        .Where (chuyenNganh => chuyenNganh.MaChuyenNganh != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
