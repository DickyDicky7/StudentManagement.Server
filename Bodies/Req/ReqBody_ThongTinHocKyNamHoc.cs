namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinHocKyNamHoc : BaseReqBody<ReqBody_ThongTinHocKyNamHoc, ThongTinHocKyNamHoc>
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

        public override Func<ReqBody_ThongTinHocKyNamHoc, Expression<Func<ThongTinHocKyNamHoc, bool>>> MatchExpression { get; set; } =
        (ReqBody_ThongTinHocKyNamHoc reqBody) => (ThongTinHocKyNamHoc model) =>
        (reqBody.MaThongTinHocKyNamHoc      == null ||
         reqBody.MaThongTinHocKyNamHoc      == model.MaThongTinHocKyNamHoc)   &&
        (reqBody.MaHocKyNamHoc              == null ||
         reqBody.MaHocKyNamHoc              == model.MaHocKyNamHoc)           &&
        (reqBody.MaSinhVien                 == null ||
         reqBody.MaSinhVien                 == model.MaSinhVien)              &&
        (reqBody.MaThongTinDangKyHocPhan    == null ||
         reqBody.MaThongTinDangKyHocPhan    == model.MaThongTinDangKyHocPhan) &&
        (reqBody.MaKetQuaHocTap             == null ||
         reqBody.MaKetQuaHocTap             == model.MaKetQuaHocTap)          &&
        (reqBody.MaKetQuaRenLuyen           == null ||
         reqBody.MaKetQuaRenLuyen           == model.MaKetQuaRenLuyen)        &&
        (reqBody.MaKhenThuong               == null ||
         reqBody.MaKhenThuong               == model.MaKhenThuong)            &&
        (reqBody.MaThongTinHocPhi           == null ||
         reqBody.MaThongTinHocPhi           == model.MaThongTinHocPhi)        &&
        (reqBody.MaThongTinHocKyNamHocTruoc == null ||
         reqBody.MaThongTinHocKyNamHocTruoc == model.MaThongTinHocKyNamHocTruoc);
    }
}
