namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ThongTinHocKyNamHoc : BaseReqBody<ThongTinHocKyNamHoc>
    {
        public long? MaThongTinHocKyNamHoc      { get; set; }
        public long? MaHocKyNamHoc              { get; set; }
        public long? MaSinhVien                 { get; set; }
        public long? MaThongTinDangKyHocPhan    { get; set; }
        public long? MaKetQuaHocTap             { get; set; }
        public long? MaKetQuaRenLuyen           { get; set; }
        public long? MaKhenThuong               { get; set; }
        public long? MaThongTinHocPhi           { get; set; }
        public long? MaThongTinHocKyNamHocTruoc { get; set; }

        public override Expression<Func<ThongTinHocKyNamHoc, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinHocKyNamHoc      == null ||
             MaThongTinHocKyNamHoc      == model.MaThongTinHocKyNamHoc)   &&
            (MaHocKyNamHoc              == null ||
             MaHocKyNamHoc              == model.MaHocKyNamHoc)           &&
            (MaSinhVien                 == null ||
             MaSinhVien                 == model.MaSinhVien)              &&
            (MaThongTinDangKyHocPhan    == null ||
             MaThongTinDangKyHocPhan    == model.MaThongTinDangKyHocPhan) &&
            (MaKetQuaHocTap             == null ||
             MaKetQuaHocTap             == model.MaKetQuaHocTap)          &&
            (MaKetQuaRenLuyen           == null ||
             MaKetQuaRenLuyen           == model.MaKetQuaRenLuyen)        &&
            (MaKhenThuong               == null ||
             MaKhenThuong               == model.MaKhenThuong)            &&
            (MaThongTinHocPhi           == null ||
             MaThongTinHocPhi           == model.MaThongTinHocPhi)        &&
            (MaThongTinHocKyNamHocTruoc == null ||
             MaThongTinHocKyNamHocTruoc == model.MaThongTinHocKyNamHocTruoc);
        }
    }

    public record class JustForInsertReqBody_ThongTinHocKyNamHoc : ReqBody_ThongTinHocKyNamHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaThongTinHocKyNamHoc { get; set; }
    }
}
