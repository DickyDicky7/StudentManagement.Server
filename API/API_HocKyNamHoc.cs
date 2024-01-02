namespace StudentManagement.Server.API
{
    public static class API_HocKyNamHoc
    {
        public static WebApplication MapAPI_HocKyNamHoc(this WebApplication app)
        {
            app
                .MapPost(@"/hoc-ky-nam-hoc/get-many", InternalMethods.HocKyNamHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/hoc-ky-nam-hoc/add-many", InternalMethods.HocKyNamHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HocKyNamHoc>> HocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_HocKyNamHoc reqBodyFilter)
            {
                ResBody_GetMany<HocKyNamHoc> resBody_GetMany = new()
                {
                    Result = await context.HocKyNamHocs
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<HocKyNamHoc>> HocKyNamHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_HocKyNamHoc, HocKyNamHoc> reqBody_AddMany)
            {
                ResBody_AddMany<HocKyNamHoc> resBody_AddMany = new();
                IEnumerable    <HocKyNamHoc> hocKyNamHocs    = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.HocKyNamHocs.AddRangeAsync(hocKyNamHocs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = hocKyNamHocs
                        .Where (hocKyNamHoc => hocKyNamHoc.MaHocKyNamHoc != default)
                        .Select(hocKyNamHoc => hocKyNamHoc.MaHocKyNamHoc);
                }
                else
                {
                    resBody_AddMany.Result        = hocKyNamHocs
                        .Where (hocKyNamHoc => hocKyNamHoc.MaHocKyNamHoc != default);
                }
                return resBody_AddMany;
            }

        }
    }
}
