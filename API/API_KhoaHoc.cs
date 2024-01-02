namespace StudentManagement.Server.API
{
    public static class API_KhoaHoc
    {
        public static WebApplication MapAPI_KhoaHoc(this WebApplication app)
        {
            app
                .MapPost(@"/khoa-hoc/get-many", InternalMethods.KhoaHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/khoa-hoc/add-many", InternalMethods.KhoaHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/khoa-hoc/remove-many", InternalMethods.KhoaHoc_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhoaHoc>> KhoaHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_KhoaHoc, KhoaHoc> reqBody_GetMany)
            {
                ResBody_GetMany<KhoaHoc> resBody_GetMany = new()
                {
                    Result = await context.KhoaHocs
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<KhoaHoc>> KhoaHoc_AddMany(
                [FromServices] ApplicationDbContext  context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KhoaHoc, KhoaHoc> reqBody_AddMany)
            {
                ResBody_AddMany<KhoaHoc> resBody_AddMany = new();
                IEnumerable    <KhoaHoc> khoaHocs        = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.KhoaHocs.AddRangeAsync(khoaHocs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = khoaHocs
                        .Where (khoaHoc => khoaHoc.MaKhoaHoc != default)
                        .Select(khoaHoc => khoaHoc.MaKhoaHoc);
                }
                else
                {
                    resBody_AddMany.Result        = khoaHocs
                        .Where (khoaHoc => khoaHoc.MaKhoaHoc != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<KhoaHoc>> KhoaHoc_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_KhoaHoc, KhoaHoc> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KhoaHoc> resBody_RemoveMany = new();
                IQueryable        <KhoaHoc> khoaHocs           = context.KhoaHocs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = khoaHocs
                    .Select(khoaHoc => khoaHoc.MaKhoaHoc);
                }
                else
                {
                    resBody_RemoveMany.Result        = khoaHocs;
                }
                context.KhoaHocs
                       .RemoveRange(khoaHocs);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
