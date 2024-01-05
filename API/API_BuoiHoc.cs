namespace StudentManagement.Server.API
{
    public static class API_BuoiHoc
    {
        public static WebApplication MapAPI_BuoiHoc(this WebApplication app)
        {
            app
                .MapPost (@"/buoi-hoc/get-many", InternalMethods.BuoiHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/buoi-hoc/add-many", InternalMethods.BuoiHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/buoi-hoc/update-many", InternalMethods.BuoiHoc_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/buoi-hoc/remove-many", InternalMethods.BuoiHoc_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BuoiHoc>> BuoiHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_BuoiHoc,  BuoiHoc> reqBody_GetMany)
            {
                ResBody_GetMany<BuoiHoc> resBody_GetMany = new()
                {
                    Result = (
                    await context.BuoiHocs
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           BuoiHoc>> BuoiHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BuoiHoc,  BuoiHoc> reqBody_AddMany)
            {
                ResBody_AddMany<BuoiHoc> resBody_AddMany = new();
                List           <BuoiHoc> buoiHocs        = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
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

            public static async Task<ResBody_UpdateMany<BuoiHoc>> BuoiHoc_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_BuoiHoc,  BuoiHoc> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<BuoiHoc> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.BuoiHocs.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long   >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<BuoiHoc>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<BuoiHoc>> BuoiHoc_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_BuoiHoc,  BuoiHoc> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<BuoiHoc> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long   >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<BuoiHoc>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.BuoiHocs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
