namespace StudentManagement.Server.API
{
    public static class API_KetQuaHocTap
    {
        public static WebApplication MapAPI_KetQuaHocTap(this WebApplication app)
        {
            app
                .MapPost(@"/ket-qua-hoc-tap/get-many", InternalMethods.KetQuaHocTap_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/ket-qua-hoc-tap/add-many", InternalMethods.KetQuaHocTap_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/ket-qua-hoc-tap/remove-many", InternalMethods.KetQuaHocTap_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaHocTap>> KetQuaHocTap_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_KetQuaHocTap, KetQuaHocTap> reqBody_GetMany)
            {
                ResBody_GetMany<KetQuaHocTap> resBody_GetMany = new()
                {
                    Result = await context.KetQuaHocTaps
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<KetQuaHocTap>> KetQuaHocTap_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KetQuaHocTap, KetQuaHocTap> reqBody_AddMany)
            {
                ResBody_AddMany<KetQuaHocTap> resBody_AddMany = new();
                IEnumerable    <KetQuaHocTap> ketQuaHocTaps   = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.KetQuaHocTaps.AddRangeAsync(ketQuaHocTaps);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = ketQuaHocTaps
                    .Where (ketQuaHocTap => ketQuaHocTap.MaKetQuaHocTap != default)
                    .Select(ketQuaHocTap => ketQuaHocTap.MaKetQuaHocTap);
                }
                else
                {
                    resBody_AddMany.Result        = ketQuaHocTaps
                    .Where (ketQuaHocTap => ketQuaHocTap.MaKetQuaHocTap != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<KetQuaHocTap>> KetQuaHocTap_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_KetQuaHocTap, KetQuaHocTap> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KetQuaHocTap> resBody_RemoveMany = new();
                IQueryable        <KetQuaHocTap> ketQuaHocTaps      = context.KetQuaHocTaps.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = ketQuaHocTaps
                    .Select(ketQuaHocTap => ketQuaHocTap.MaKetQuaHocTap);
                }
                else
                {
                    resBody_RemoveMany.Result        = ketQuaHocTaps;
                }
                context.KetQuaHocTaps
                       .RemoveRange(ketQuaHocTaps);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
