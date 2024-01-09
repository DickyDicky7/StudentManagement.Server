namespace StudentManagement.Server.API
{
    public static class API_KhenThuong
    {
        public static WebApplication MapAPI_KhenThuong(this WebApplication app)
        {
            app
                .MapPost (@"/khen-thuong/get-many", InternalMethods.KhenThuong_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/khen-thuong/add-many", InternalMethods.KhenThuong_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/khen-thuong/update-many", InternalMethods.KhenThuong_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/khen-thuong/remove-many", InternalMethods.KhenThuong_RemoveMany)
                .WithTags (@"Remove many");

            app
                .MapPost (@"/khen-thuong/xet-khen-thuong", InternalMethods.KhenThuong_XetKhenThuong)
                .WithTags(@"Xét khen thưởng");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhenThuong>> KhenThuong_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_KhenThuong,  KhenThuong> reqBody_GetMany)
            {
                ResBody_GetMany<KhenThuong> resBody_GetMany = new()
                {
                    Result = await context.KhenThuongs
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           KhenThuong>> KhenThuong_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KhenThuong,  KhenThuong> reqBody_AddMany)
            {
                ResBody_AddMany<KhenThuong> resBody_AddMany = new() ;
                List           <KhenThuong> khenThuongs     = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
                await   context.KhenThuongs.AddRangeAsync(khenThuongs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = khenThuongs
                    .Where (khenThuong => khenThuong.MaKhenThuong != default)
                    .Select(khenThuong => khenThuong.MaKhenThuong);
                }
                else
                {
                    resBody_AddMany.Result        = khenThuongs
                    .Where (khenThuong => khenThuong.MaKhenThuong != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<KhenThuong>> KhenThuong_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_KhenThuong,  KhenThuong> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<KhenThuong> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.KhenThuongs.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModelExpression());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long      >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<KhenThuong>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<KhenThuong>> KhenThuong_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_KhenThuong,  KhenThuong> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<KhenThuong> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long      >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<KhenThuong>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.KhenThuongs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

            public static async Task<IResult> KhenThuong_XetKhenThuong(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_XetKhenThuong reqBody_XetKhenThuong)
            {
                ResBody_XetKhenThuong resBody_XetKhenThuong = new();
                resBody_XetKhenThuong.DanhSachXetKhenThuongKetQua = new();

                foreach (ReqBody_XetKhenThuongTungSinhVienHocKyNamHoc
                         reqBody_XetKhenThuongTungSinhVienHocKyNamHoc in reqBody_XetKhenThuong.DanhSachXetKhenThuong)
                {
                    KetQuaHocTap ketQuaHocTap = (await context.KetQuaHocTaps.SingleOrDefaultAsync(ketQuaHocTap =>
                    ketQuaHocTap.MaSinhVien    == reqBody_XetKhenThuongTungSinhVienHocKyNamHoc.MaSinhVien &&
                    ketQuaHocTap.MaHocKyNamHoc == reqBody_XetKhenThuongTungSinhVienHocKyNamHoc.MaHocKyNamHoc))!;
                    if (ketQuaHocTap == null)
                    {
                        resBody_XetKhenThuong.DanhSachXetKhenThuongKetQua.Add(new()
                        {
                             LyDoTuChoiXetKhenThuong = "Related KetQuaHocTap not found",
                        });
                        continue;
                    }
                    KetQuaRenLuyen ketQuaRenLuyen = (await context.KetQuaRenLuyens.SingleOrDefaultAsync(ketQuaRenLuyen =>
                    ketQuaRenLuyen.MaSinhVien    == reqBody_XetKhenThuongTungSinhVienHocKyNamHoc.MaSinhVien &&
                    ketQuaRenLuyen.MaHocKyNamHoc == reqBody_XetKhenThuongTungSinhVienHocKyNamHoc.MaHocKyNamHoc))!;
                    if (ketQuaRenLuyen == null)
                    {

                        resBody_XetKhenThuong.DanhSachXetKhenThuongKetQua.Add(new()
                        {
                            LyDoTuChoiXetKhenThuong = "Related KetQuaRenLuyen not found",
                        });
                        continue;
                    }
                    KhenThuong khenThuong = new()
                    {
                        MaHocKyNamHoc = reqBody_XetKhenThuongTungSinhVienHocKyNamHoc.MaHocKyNamHoc,
                        MaSinhVien    = reqBody_XetKhenThuongTungSinhVienHocKyNamHoc.MaSinhVien  ,
                        XepLoaiKhenThuong = string.Empty,
                    };
                    bool duDieuKienKhenThuong = khenThuong.KiemTraDuDieuKienKhenThuong(ketQuaHocTap, ketQuaRenLuyen);
                    if ( duDieuKienKhenThuong )
                    {
                        khenThuong.QuyetDinhXepLoaiKhenThuong(ketQuaHocTap, ketQuaRenLuyen);
                        context                   .KhenThuongs.Add(khenThuong);
                        resBody_XetKhenThuong.DanhSachXetKhenThuongKetQua.Add(new()
                        {
                             KetQuaKhenThuong = khenThuong,
                        });
                    }
                    else
                    {
                        resBody_XetKhenThuong.DanhSachXetKhenThuongKetQua.Add(new()
                        {
                            LyDoTuChoiXetKhenThuong = "KetQuaHocTap hay KetQuaRenLuyen not meet requirements",
                        });
                    }
                }
                await  context.SaveChangesAsync();
                return Results.Ok(resBody_XetKhenThuong);
            }

            public record class ReqBody_XetKhenThuongTungSinhVienHocKyNamHoc
            {
                public long MaSinhVien    { get; set; }
                public long MaHocKyNamHoc { get; set; }
            }

            public record class ReqBody_XetKhenThuong
            {
                public List<ReqBody_XetKhenThuongTungSinhVienHocKyNamHoc> DanhSachXetKhenThuong       { get; set; } = null!;
            }

            public record class ResBody_XetKhenThuong
            {
                public List<ResBody_XetKhenThuongTungSinhVienHocKyNamHoc> DanhSachXetKhenThuongKetQua { get; set; } = null!;
            }

            public record class ResBody_XetKhenThuongTungSinhVienHocKyNamHoc
            {
                [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
                public string    ? LyDoTuChoiXetKhenThuong { get; set; }
                [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
                public KhenThuong?        KetQuaKhenThuong { get; set; }
            }
        }
    }
}
