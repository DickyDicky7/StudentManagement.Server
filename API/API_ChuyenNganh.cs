﻿namespace StudentManagement.Server.API
{
    public static class API_ChuyenNganh
    {
        public static WebApplication MapAPI_ChuyenNganh(this WebApplication app)
        {
            app
                .MapPost(@"/chuyen-nganh/get-many", InternalMethods.ChuyenNganh_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/chuyen-nganh/add-many", InternalMethods.ChuyenNganh_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/chuyen-nganh/remove-many", InternalMethods.ChuyenNganh_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ChuyenNganh>> ChuyenNganh_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_ChuyenNganh, ChuyenNganh> reqBody_GetMany)
            {
                ResBody_GetMany<ChuyenNganh> resBody_GetMany = new()
                {
                    Result = await context.ChuyenNganhs
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<ChuyenNganh>> ChuyenNganh_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ChuyenNganh, ChuyenNganh> reqBody_AddMany)
            {
                ResBody_AddMany<ChuyenNganh> resBody_AddMany = new();
                IEnumerable    <ChuyenNganh> chuyenNganhs    = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.ChuyenNganhs.AddRangeAsync(chuyenNganhs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = chuyenNganhs
                        .Where (chuyenNganh => chuyenNganh.MaChuyenNganh != default)
                        .Select(chuyenNganh => chuyenNganh.MaChuyenNganh);
                }
                else
                {
                    resBody_AddMany.Result        = chuyenNganhs
                        .Where (chuyenNganh => chuyenNganh.MaChuyenNganh != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_RemoveMany<ChuyenNganh>> ChuyenNganh_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_ChuyenNganh, ChuyenNganh> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<ChuyenNganh> resBody_RemoveMany = new();
                IQueryable        <ChuyenNganh> chuyenNganhs       = context.ChuyenNganhs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = chuyenNganhs
                    .Select(chuyenNganh => chuyenNganh.MaChuyenNganh);
                }
                else
                {
                    resBody_RemoveMany.Result        = chuyenNganhs;
                }
                context.ChuyenNganhs
                       .RemoveRange(chuyenNganhs);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
