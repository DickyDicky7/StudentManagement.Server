namespace StudentManagement.Server.API
{
    public static class API_BuoiHoc
    {
        public static WebApplication MapAPI_BuoiHoc(this WebApplication app)
        {
            app
                .MapPost(@"/buoi-hoc/get-many", InternalMethods.BuoiHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/buoi-hoc/add-many", InternalMethods.BuoiHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BuoiHoc>> BuoiHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BuoiHoc reqBodyFilter)
            {
                ResBody_GetMany<BuoiHoc> resBody_GetMany = new()
                {
                    Result = (
                    await context.BuoiHocs
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<BuoiHoc>> BuoiHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BuoiHoc, BuoiHoc> reqBody_AddMany)
            {
                ResBody_AddMany<BuoiHoc> resBody_AddMany  = new  () ;
                IEnumerable    <BuoiHoc> buoiHocs = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.BuoiHocs.AddRangeAsync(buoiHocs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = buoiHocs
                        .Where (buoiHoc => buoiHoc.MaBuoiHoc != default)
                        .Select(buoiHoc => buoiHoc.MaBuoiHoc);
                }
                else
                {
                    resBody_AddMany.Result        = buoiHocs
                        .Where (buoiHoc => buoiHoc.MaBuoiHoc != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
