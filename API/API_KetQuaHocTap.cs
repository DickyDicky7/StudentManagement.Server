namespace StudentManagement.Server.API
{
    public static class API_KetQuaHocTap
    {
        public static WebApplication MapAPI_KetQuaHocTap(this WebApplication app)
        {
            app
                .MapPost(@"/ket-qua-hoc-tap/get-many", InternalMethods.KetQuaHocTap_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/ket-qua-hoc-tap/add-many", InternalMethods.KetQuaHocTap_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaHocTap>> KetQuaHocTap_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KetQuaHocTap reqBodyFilter)
            {
                ResBody_GetMany<KetQuaHocTap> resBody_GetMany = new()
                {
                    Result = await context.KetQuaHocTaps
                    .Where(reqBodyFilter
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

        }
    }
}
