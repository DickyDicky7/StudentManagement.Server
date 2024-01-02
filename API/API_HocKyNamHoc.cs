namespace StudentManagement.Server.API
{
    public static class API_HocKyNamHoc
    {
        public static WebApplication MapAPI_HocKyNamHoc(this WebApplication app)
        {
            app
                .MapPost(@"/hoc-ky-nam-hoc/get-many", InternalMethods.HocKyNamHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/hoc-ky-nam-hoc/add-many", InternalMethods.HocKyNamHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/hoc-ky-nam-hoc/remove-many", InternalMethods.HocKyNamHoc_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HocKyNamHoc>> HocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_HocKyNamHoc, HocKyNamHoc> reqBody_GetMany)
            {
                ResBody_GetMany<HocKyNamHoc> resBody_GetMany = new()
                {
                    Result = await context.HocKyNamHocs
                    .Where(reqBody_GetMany.FilterBy
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

            public static async Task<ResBody_RemoveMany<HocKyNamHoc>> HocKyNamHoc_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_HocKyNamHoc, HocKyNamHoc> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<HocKyNamHoc> resBody_RemoveMany = new();
                IQueryable        <HocKyNamHoc> hocKyNamHocs       = context.HocKyNamHocs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = hocKyNamHocs
                    .Select(hocKyNamHoc => hocKyNamHoc.MaHocKyNamHoc);
                }
                else
                {
                    resBody_RemoveMany.Result        = hocKyNamHocs;
                }
                context.HocKyNamHocs
                       .RemoveRange(hocKyNamHocs);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
