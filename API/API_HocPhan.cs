namespace StudentManagement.Server.API
{
    public static class API_HocPhan
    {
        public static WebApplication MapAPI_HocPhan(this WebApplication app)
        {
            app
                .MapPost(@"/hoc-phan/get-many", InternalMethods.HocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/hoc-phan/add-many", InternalMethods.HocPhan_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/hoc-phan/remove-many", InternalMethods.HocPhan_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HocPhan>> HocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_HocPhan, HocPhan> reqBody_GetMany)
            {
                ResBody_GetMany<HocPhan> resBody_GetMany = new()
                {
                    Result = await context.HocPhans
                    .Where(reqBody_GetMany.FilterBy
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

            public static async Task<ResBody_RemoveMany<HocPhan>> HocPhan_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_HocPhan, HocPhan> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<HocPhan> resBody_RemoveMany = new();
                IQueryable        <HocPhan> hocPhans           = context.HocPhans.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = hocPhans
                    .Select(hocPhan => hocPhan.MaHocPhan);
                }
                else
                {
                    resBody_RemoveMany.Result        = hocPhans;
                }
                context.HocPhans
                       .RemoveRange(hocPhans);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
