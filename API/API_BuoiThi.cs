namespace StudentManagement.Server.API
{
    public static class API_BuoiThi
    {
        public static WebApplication MapAPI_BuoiThi(this WebApplication app)
        {
            app
                .MapPost(@"/buoi-thi/get-many", InternalMethods.BuoiThi_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/buoi-thi/add-many", InternalMethods.BuoiThi_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BuoiThi>> BuoiThi_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BuoiThi reqBodyFilter)
            {
                ResBody_GetMany<BuoiThi> resBody_GetMany = new()
                {
                    Result = (
                    await context.BuoiThis
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<BuoiThi>> BuoiThi_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BuoiThi, BuoiThi> reqBody_AddMany)
            {
                ResBody_AddMany<BuoiThi> resBody_AddMany  = new();
                IEnumerable    <BuoiThi> buoiThis = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.BuoiThis.AddRangeAsync(buoiThis);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = buoiThis
                        .Where (buoiThi => buoiThi.MaBuoiThi != default)
                        .Select(buoiThi => buoiThi.MaBuoiThi);
                }
                else
                {
                    resBody_AddMany.Result        = buoiThis
                        .Where (buoiThi => buoiThi.MaBuoiThi != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
