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
                foreach (KetQuaHocTap ketQuaHocTap in ketQuaHocTaps)
                {
                    ThongTinDangKyHocPhan
                    thongTinDangKyHocPhan = context.
                    ThongTinDangKyHocPhans
                    .    Include(row => row.DanhSachDangKyHocPhans)
                    .ThenInclude(row => row.BangDiemHocPhan)
                    .ThenInclude(row => row.        HocPhan)
                    .Single(row => row.MaSinhVien    == ketQuaHocTap.MaSinhVien
                                && row.MaHocKyNamHoc == ketQuaHocTap.MaHocKyNamHoc);
                    ketQuaHocTap.DiemTrungBinhHocKyTinh
                    (thongTinDangKyHocPhan
                    .DanhSachDangKyHocPhans
                    .Select(row => row.BangDiemHocPhan));
                    Common.BacDiem bacDiem = ketQuaHocTap.TinhBacDiemHocTap()!;
                    ketQuaHocTap.XepLoaiHocTap =  bacDiem.XepLoai!;
                }
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
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModelExpression());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long        >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<KetQuaHocTap>();
                }
                List    <KetQuaHocTap>ketQuaHocTaps = await context.KetQuaHocTaps
                .Where(reqBody_UpdateMany.FilterBy.MatchExpression())
                .ToListAsync();
                foreach (KetQuaHocTap ketQuaHocTap in ketQuaHocTaps)
                {
                    ThongTinDangKyHocPhan
                    thongTinDangKyHocPhan = context.
                    ThongTinDangKyHocPhans
                    .    Include(row => row.DanhSachDangKyHocPhans)
                    .ThenInclude(row => row.BangDiemHocPhan)
                    .ThenInclude(row => row.        HocPhan)
                    .Single(row => row.MaSinhVien    == ketQuaHocTap.MaSinhVien
                                && row.MaHocKyNamHoc == ketQuaHocTap.MaHocKyNamHoc);
                    ketQuaHocTap.DiemTrungBinhHocKyTinh
                    (thongTinDangKyHocPhan
                    .DanhSachDangKyHocPhans
                    .Select(row => row.BangDiemHocPhan));
                    Common.BacDiem bacDiem = ketQuaHocTap.TinhBacDiemHocTap()!;
                    ketQuaHocTap.XepLoaiHocTap =  bacDiem.XepLoai!;
                    await
                         context. KetQuaHocTaps.Where(row => row.MaKetQuaHocTap == ketQuaHocTap.MaKetQuaHocTap)
                          .ExecuteUpdateAsync(setter =>
                          setter.SetProperty (row => row.DiemTrungBinhHocKy, ketQuaHocTap.DiemTrungBinhHocKy)
                                .SetProperty (row => row.     XepLoaiHocTap, ketQuaHocTap.     XepLoaiHocTap) );
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

            //public static async Task<IResult> KetQuaHocTap_BangDiemChiTiet(
            //    [FromServices] ApplicationDbContext context,
            //    [FromQuery(Name = "ma-sinh-vien")] long maSinhVien, [FromQuery(Name = "ma-hoc-ky-nam-hoc")] long maHocKyNamHoc)
            //{
            //    ThongTinDangKyHocPhan thongTinDangKyHocPhan = (await context.ThongTinDangKyHocPhans
            //    .    Include(row=>row.DanhSachDangKyHocPhans)
            //    .ThenInclude(row=>row.BangDiemHocPhan)
            //    .ThenInclude(row=>row.HocPhan)
            //    .ThenInclude(row=>row. MonHoc)
            //    .SingleOrDefaultAsync(thongTinDangKyHocPhan => thongTinDangKyHocPhan.MaSinhVien    == maSinhVien
            //                                                && thongTinDangKyHocPhan.MaHocKyNamHoc == maHocKyNamHoc))!;
            //    if (thongTinDangKyHocPhan == null)
            //    {
            //        return Results.BadRequest(new ResBody_Helper<string>()
            //        {
            //            Result = "invalid ma-sinh-vien or ma-hoc-ky-nam-hoc: ma-sinh-vien or ma-hoc-ky-nam-hoc not found",
            //        });
            //    }

                
            //}
        }
    }
}
