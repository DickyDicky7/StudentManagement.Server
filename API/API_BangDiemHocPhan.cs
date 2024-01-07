﻿namespace StudentManagement.Server.API
{
    public static class API_BangDiemHocPhan
    {
        public static WebApplication MapAPI_BangDiemHocPhan(this WebApplication app)
        {
            app
                .MapPost (@"/bang-diem-hoc-phan/get-many", InternalMethods.BangDiemHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/bang-diem-hoc-phan/add-many", InternalMethods.BangDiemHocPhan_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/bang-diem-hoc-phan/update-many", InternalMethods.BangDiemHocPhan_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/bang-diem-hoc-phan/remove-many", InternalMethods.BangDiemHocPhan_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BangDiemHocPhan>> BangDiemHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_GetMany)
            {
                ResBody_GetMany<BangDiemHocPhan> resBody_GetMany = new()
                {
                    Result = (
                    await context.BangDiemHocPhans
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()
                    ),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           BangDiemHocPhan>> BangDiemHocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<BangDiemHocPhan> resBody_AddMany  = new();
                List           <BangDiemHocPhan> bangDiemHocPhans = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
                await   context.BangDiemHocPhans.AddRangeAsync(bangDiemHocPhans);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = bangDiemHocPhans
                        .Where (bangDiemHocPhan => bangDiemHocPhan.MaBangDiemHocPhan != default)
                        .Select(bangDiemHocPhan => bangDiemHocPhan.MaBangDiemHocPhan);
                }
                else
                {
                    resBody_AddMany.Result        = bangDiemHocPhans
                        .Where (bangDiemHocPhan => bangDiemHocPhan.MaBangDiemHocPhan != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<BangDiemHocPhan>> BangDiemHocPhan_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<BangDiemHocPhan> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.BangDiemHocPhans.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long           >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<BangDiemHocPhan>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<BangDiemHocPhan>> BangDiemHocPhan_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<BangDiemHocPhan> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long           >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<BangDiemHocPhan>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.BangDiemHocPhans.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }
        }
    }
}
