﻿namespace StudentManagement.Server.API
{
    public static class API_BoMon
    {
        public static WebApplication MapAPI_BoMon(this WebApplication app)
        {
            app
                .MapPost(@"/bo-mon/get-many", InternalMethods.BoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/bo-mon/add-many", InternalMethods.BoMon_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BoMon>> BoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BoMon reqBodyFilter)
            {
                ResBody_GetMany<BoMon> resBody_GetMany = new()
                {
                    Result = await context.BoMons
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<BoMon>> BoMon_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BoMon, BoMon> reqBody_AddMany)
            {
                ResBody_AddMany<BoMon> resBody_AddMany = new();
                IEnumerable    <BoMon> boMons          = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.BoMons.AddRangeAsync(boMons);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = boMons
                        .Where (boMon => boMon.MaBoMon != default)
                        .Select(boMon => boMon.MaBoMon);
                }
                else
                {
                    resBody_AddMany.Result        = boMons
                        .Where (boMon => boMon.MaBoMon != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
