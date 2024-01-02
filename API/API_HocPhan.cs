namespace StudentManagement.Server.API
{
    public static class API_HocPhan
    {
        public static WebApplication MapAPI_HocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/hoc-phan/get-many", InternalMethods.HocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/hoc-phan/add-many", InternalMethods.HocPhan_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HocPhan>> HocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HocPhan reqBodyFilter)
            {
                ResBody_GetMany<HocPhan> resBody_GetMany = new()
                {
                    Result = await context.HocPhans
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<HocPhan>> HocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_HocPhan, HocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<HocPhan> resBody_AddMany = new();
                IEnumerable    <HocPhan> hocPhans        = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.HocPhans.AddRangeAsync(hocPhans);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = hocPhans
                        .Where (hocPhan => hocPhan.MaHocPhan != default)
                        .Select(hocPhan => hocPhan.MaHocPhan);
                }
                else
                {
                    resBody_AddMany.Result        = hocPhans
                        .Where (hocPhan => hocPhan.MaHocPhan != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
