namespace StudentManagement.Server.API
{
    public static class API_MonHoc
    {
        public static WebApplication MapAPI_MonHoc(this WebApplication app)
        {
            app
                .MapPost(@"/mon-hoc/get-many", InternalMethods.MonHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/mon-hoc/add-many", InternalMethods.MonHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<MonHoc>> MonHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_MonHoc reqBodyFilter)
            {
                ResBody_GetMany<MonHoc> resBody_GetMany = new()
                {
                    Result = (await context.MonHocs
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<MonHoc>> MonHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_MonHoc, MonHoc> reqBody_AddMany)
            {
                ResBody_AddMany<MonHoc> resBody_AddMany = new();
                IEnumerable    <MonHoc> monHocs         = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.MonHocs.AddRangeAsync(monHocs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = monHocs
                        .Where (monHoc => monHoc.MaMonHoc != default)
                        .Select(monHoc => monHoc.MaMonHoc);
                }
                else
                {
                    resBody_AddMany.Result        = monHocs
                        .Where (monHoc => monHoc.MaMonHoc != default);
                }
                return resBody_AddMany;
            }

        }
    }
}
