namespace StudentManagement.Server.API
{
    public static class API_KetQuaRenLuyen
    {
        public static WebApplication MapAPI_KetQuaRenLuyen(this WebApplication app)
        {
            app
                .MapPost(@"/ket-qua-ren-luyen/get-many", InternalMethods.KetQuaRenLuyen_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/ket-qua-ren-luyen/add-many", InternalMethods.KetQuaRenLuyen_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaRenLuyen>> KetQuaRenLuyen_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KetQuaRenLuyen reqBodyFilter)
            {
                ResBody_GetMany<KetQuaRenLuyen> resBody_GetMany = new()
                {
                    Result = await context.KetQuaRenLuyens
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<KetQuaRenLuyen>> KetQuaRenLuyen_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KetQuaRenLuyen, KetQuaRenLuyen> reqBody_AddMany)
            {
                ResBody_AddMany<KetQuaRenLuyen> resBody_AddMany = new();
                IEnumerable    <KetQuaRenLuyen> ketQuaRenLuyens = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.KetQuaRenLuyens.AddRangeAsync(ketQuaRenLuyens);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = ketQuaRenLuyens
                    .Where (ketQuaRenLuyen => ketQuaRenLuyen.MaKetQuaRenLuyen != default)
                    .Select(ketQuaRenLuyen => ketQuaRenLuyen.MaKetQuaRenLuyen);
                }
                else
                {
                    resBody_AddMany.Result        = ketQuaRenLuyens
                    .Where (ketQuaRenLuyen => ketQuaRenLuyen.MaKetQuaRenLuyen != default);
                }
                return resBody_AddMany;
            }

        }
    }
}
