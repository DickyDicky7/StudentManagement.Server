﻿namespace StudentManagement.Server.API
{
    public static class API_HoSo
    {
        public static WebApplication MapAPI_HoSo(this WebApplication app)
        {
            app
                .MapPost(@"/ho-so/get-many", InternalMethods.HoSo_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/ho-so/add-many", InternalMethods.HoSo_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/ho-so/remove-many", InternalMethods.HoSo_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<HoSo>> HoSo_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_HoSo, HoSo> reqBody_GetMany)
            {
                ResBody_GetMany<HoSo> resBody_GetMany = new()
                {
                    Result = await context.HoSos
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<HoSo>> HoSo_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_HoSo, HoSo> reqBody_AddMany)
            {
                ResBody_AddMany<HoSo> resBody_AddMany = new();
                IEnumerable    <HoSo> hoSos           = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.HoSos.AddRangeAsync(hoSos);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = hoSos
                        .Where (hoSo => hoSo.MaHoSo != default)
                        .Select(hoSo => hoSo.MaHoSo);
                }
                else
                {
                    resBody_AddMany.Result        = hoSos
                        .Where (hoSo => hoSo.MaHoSo != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<HoSo>> HoSo_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_HoSo, HoSo> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<HoSo> resBody_RemoveMany = new();
                IQueryable        <HoSo> hoSos              = context.HoSos.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = hoSos
                    .Select(hoSo => hoSo.MaHoSo);
                }
                else
                {
                    resBody_RemoveMany.Result        = hoSos;
                }
                context.HoSos
                       .RemoveRange(hoSos);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}