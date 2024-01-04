namespace StudentManagement.Server.API
{
    public static class API_BuoiThi
    {
        public static WebApplication MapAPI_BuoiThi(this WebApplication app)
        {
            app
                .MapPost (@"/buoi-thi/get-many", InternalMethods.BuoiThi_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/buoi-thi/add-many", InternalMethods.BuoiThi_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/buoi-thi/update-many", InternalMethods.BuoiThi_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/buoi-thi/remove-many", InternalMethods.BuoiThi_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BuoiThi>> BuoiThi_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_BuoiThi,  BuoiThi> reqBody_GetMany)
            {
                ResBody_GetMany<BuoiThi> resBody_GetMany = new()
                {
                    Result = (
                    await context.BuoiThis
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           BuoiThi>> BuoiThi_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BuoiThi,  BuoiThi> reqBody_AddMany)
            {
                ResBody_AddMany<BuoiThi> resBody_AddMany = new();
                IEnumerable    <BuoiThi> buoiThis        = reqBody_AddMany
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

            public static async Task<ResBody_UpdateMany<BuoiThi>> BuoiThi_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_BuoiThi,  BuoiThi> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<BuoiThi> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.BuoiThis.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long   >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<BuoiThi>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<BuoiThi>> BuoiThi_RemoveMany(
                [FromServices] ApplicationDbContext   context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_BuoiThi,  BuoiThi> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<BuoiThi> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long   >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<BuoiThi>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.BuoiThis.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
