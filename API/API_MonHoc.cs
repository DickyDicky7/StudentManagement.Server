﻿namespace StudentManagement.Server.API
{
    public static class API_MonHoc
    {
        public static WebApplication MapAPI_MonHoc(this WebApplication app)
        {
            app
                .MapPost (@"/mon-hoc/get-many", InternalMethods.MonHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/mon-hoc/add-many", InternalMethods.MonHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/mon-hoc/update-many", InternalMethods.MonHoc_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/mon-hoc/remove-many", InternalMethods.MonHoc_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<MonHoc>> MonHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_MonHoc,  MonHoc> reqBody_GetMany)
            {
                ResBody_GetMany<MonHoc> resBody_GetMany = new()
                {
                    Result = (await context.MonHocs
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           MonHoc>> MonHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_MonHoc,  MonHoc> reqBody_AddMany)
            {
                ResBody_AddMany<MonHoc> resBody_AddMany = new();
                List           <MonHoc> monHocs         = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
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

            public static async Task<ResBody_UpdateMany<MonHoc>> MonHoc_UpdateMany(
                [FromServices] ApplicationDbContext    context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_MonHoc,  MonHoc> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<MonHoc> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.MonHocs.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long  >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<MonHoc>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<MonHoc>> MonHoc_RemoveMany(
                [FromServices] ApplicationDbContext    context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_MonHoc,  MonHoc> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<MonHoc> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long  >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<MonHoc>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.MonHocs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
