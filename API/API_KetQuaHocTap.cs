namespace StudentManagement.Server.API
{
    public static class API_KetQuaHocTap
    {
        public static WebApplication MapAPI_KetQuaHocTap(this WebApplication app)
        {
            app
                .MapPost (@"/ket-qua-hoc-tap/get-many", InternalMethods.KetQuaHocTap_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/ket-qua-hoc-tap/add-many", InternalMethods.KetQuaHocTap_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"ket-qua-hoc-tap/update-many", InternalMethods.KetQuaHocTap_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/ket-qua-hoc-tap/remove-many", InternalMethods.KetQuaHocTap_RemoveMany)
                .WithTags (@"Remove many");

            app
                .MapGet  (@"/ket-qua-hoc-tap/get-thang-diem-danh-gia-ket-qua-hoc-tap", InternalMethods.KetQuaHocTap_GetThangDiemDanhGiaKetQuaHocTap)
                .WithTags(@"Thang điểm đánh giá kết quả học tập");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaHocTap>> KetQuaHocTap_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_KetQuaHocTap,  KetQuaHocTap> reqBody_GetMany)
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

            public static async Task<ResBody_AddMany<           KetQuaHocTap>> KetQuaHocTap_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KetQuaHocTap,  KetQuaHocTap> reqBody_AddMany)
            {
                ResBody_AddMany<KetQuaHocTap> resBody_AddMany = new();
                List           <KetQuaHocTap> ketQuaHocTaps   = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
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

            public static async Task<ResBody_UpdateMany<KetQuaHocTap>> KetQuaHocTap_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_KetQuaHocTap,  KetQuaHocTap> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<KetQuaHocTap> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.KetQuaHocTaps.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long        >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<KetQuaHocTap>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<KetQuaHocTap>> KetQuaHocTap_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_KetQuaHocTap,  KetQuaHocTap> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KetQuaHocTap> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long        >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<KetQuaHocTap>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.KetQuaHocTaps.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

            public static async Task<IResult> KetQuaHocTap_GetThangDiemDanhGiaKetQuaHocTap(
                )
            {
                await
                Task.CompletedTask;
                return Results.Ok(new ResBody_Helper<List<Common.BacDiem>>()
                {
                    Result = KetQuaHocTap.ThangDiemDanhGiaKetQuaHocTap,
                });
            }
        }
    }
}
