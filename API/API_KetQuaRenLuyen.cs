﻿namespace StudentManagement.Server.API
{
    public static class API_KetQuaRenLuyen
    {
        public static WebApplication MapAPI_KetQuaRenLuyen(this WebApplication app)
        {
            app
                .MapPost (@"/ket-qua-ren-luyen/get-many", InternalMethods.KetQuaRenLuyen_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/ket-qua-ren-luyen/add-many", InternalMethods.KetQuaRenLuyen_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/ket-qua-ren-luyen/update-many", InternalMethods.KetQuaRenLuyen_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/ket-qua-ren-luyen/remove-many", InternalMethods.KetQuaRenLuyen_RemoveMany)
                .WithTags (@"Remove many");

            app
                .MapGet  (@"/ket-qua-ren-luyen/get-thang-diem-danh-gia-ket-qua-ren-luyen", InternalMethods.KetQuaRenLuyen_GetThangDiemDanhGiaKetQuaRenLuyen)
                .WithTags(@"Thang điểm đánh giá kết quả rèn luyện");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KetQuaRenLuyen>> KetQuaRenLuyen_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_KetQuaRenLuyen,  KetQuaRenLuyen> reqBody_GetMany)
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

            public static async Task<IResult> KetQuaRenLuyen_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KetQuaRenLuyen,  KetQuaRenLuyen> reqBody_AddMany)
            {
                ResBody_AddMany<KetQuaRenLuyen> resBody_AddMany = new();
                List           <KetQuaRenLuyen> ketQuaRenLuyens = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList ();
                foreach (KetQuaRenLuyen ketQuaRenLuyen in ketQuaRenLuyens)
                {
                    if  (ketQuaRenLuyen.SoDiemRenLuyen > 100
                    ||   ketQuaRenLuyen.SoDiemRenLuyen < 000)
                    {
                        return  Results.BadRequest(new ResBody_Helper<string>()
                        {
                            Result = "invalid soDiemRenLuyen: soDiemRenLuyen must be between 0 and 100",
                        });
                    }
                         Common.BacDiem bacDiem =
                         ketQuaRenLuyen.TinhBacDiemRenLuyen()!;
                         ketQuaRenLuyen.XepLoaiRenLuyen =    bacDiem.XepLoai !;
                }
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
                return Results.Ok(resBody_AddMany);
            }

            public static async Task <IResult>          KetQuaRenLuyen_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_KetQuaRenLuyen,  KetQuaRenLuyen> reqBody_UpdateMany)
            {
                if (reqBody_UpdateMany.UpdateTo.SoDiemRenLuyen != null
                && (reqBody_UpdateMany.UpdateTo.SoDiemRenLuyen > 100
                ||  reqBody_UpdateMany.UpdateTo.SoDiemRenLuyen < 000))
                {
                    return Results.BadRequest(new ResBody_Helper<string>()
                    {
                        Result = "invalid soDiemRenLuyen: soDiemRenLuyen must be between 0 and 100",
                    });
                }
                ResBody_UpdateMany<KetQuaRenLuyen> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.KetQuaRenLuyens.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModelExpression());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long          >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<KetQuaRenLuyen>();
                }
                List<KetQuaRenLuyen> ketQuaRenLuyens =  await context.KetQuaRenLuyens
                .Where(reqBody_UpdateMany.FilterBy.MatchExpression()).ToListAsync();
                foreach
                    (KetQuaRenLuyen  ketQuaRenLuyen in ketQuaRenLuyens)
                {
                    if  (ketQuaRenLuyen.SoDiemRenLuyen > 100
                    ||   ketQuaRenLuyen.SoDiemRenLuyen < 000)
                    {
                        return  Results.BadRequest(new ResBody_Helper<string>()
                        {
                            Result = "invalid soDiemRenLuyen: soDiemRenLuyen must be between 0 and 100",
                        });
                    }
                         Common.BacDiem bacDiem =
                         ketQuaRenLuyen.TinhBacDiemRenLuyen()!;
                         ketQuaRenLuyen.XepLoaiRenLuyen =    bacDiem.XepLoai !;
                    await
                        context.
                        KetQuaRenLuyens.Where(row => row.MaKetQuaRenLuyen == ketQuaRenLuyen.MaKetQuaRenLuyen).
                        ExecuteUpdateAsync(setter =>
                                           setter.SetProperty(row =>
                                                              row.XepLoaiRenLuyen,
                                                   ketQuaRenLuyen.XepLoaiRenLuyen));
                }
                return Results.Ok(resBody_UpdateMany);
            }

            public static async Task<ResBody_RemoveMany<KetQuaRenLuyen>> KetQuaRenLuyen_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_KetQuaRenLuyen,  KetQuaRenLuyen> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KetQuaRenLuyen> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long          >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<KetQuaRenLuyen>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.KetQuaRenLuyens.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

            public static async Task<IResult> KetQuaRenLuyen_GetThangDiemDanhGiaKetQuaRenLuyen(
                )
            {
                await
                Task.CompletedTask;
                return Results.Ok(new ResBody_Helper<List<Common.BacDiem>>()
                {
                    Result = KetQuaRenLuyen.ThangDiemDanhGiaKetQuaRenLuyen,
                });
            }
        }
    }
}
