﻿namespace StudentManagement.Server.API
{
    public static class API_KetQuaRenLuyen
    {
        public static WebApplication MapAPI_KetQuaRenLuyen(this WebApplication app)
        {
            app
                .MapPost(@"/ket-qua-ren-luyen/get-many", InternalMethods.KetQuaRenLuyen_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/ket-qua-ren-luyen/add-many", InternalMethods.KetQuaRenLuyen_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/ket-qua-ren-luyen/remove-many", InternalMethods.KetQuaRenLuyen_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaRenLuyen>> KetQuaRenLuyen_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_KetQuaRenLuyen, KetQuaRenLuyen> reqBody_GetMany)
            {
                ResBody_GetMany<KetQuaRenLuyen> resBody_GetMany = new()
                {
                    Result = await context.KetQuaRenLuyens
                    .Where(reqBody_GetMany.FilterBy
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

            public static async Task<ResBody_RemoveMany<KetQuaRenLuyen>> KetQuaRenLuyen_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_KetQuaRenLuyen, KetQuaRenLuyen> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KetQuaRenLuyen> resBody_RemoveMany = new();
                IQueryable        <KetQuaRenLuyen> ketQuaRenLuyens    = context.KetQuaRenLuyens.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = ketQuaRenLuyens
                    .Select(ketQuaRenLuyen => ketQuaRenLuyen.MaKetQuaRenLuyen);
                }
                else
                {
                    resBody_RemoveMany.Result        = ketQuaRenLuyens;
                }
                context.KetQuaRenLuyens
                       .RemoveRange(ketQuaRenLuyens);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}