namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinHocPhi : BaseReqBody<ReqBody_ThongTinHocPhi, ThongTinHocPhi>
    {
        public long    ? MaThongTinHocPhi           { get; set; }
        public decimal ? SoTienHocPhiTheoQuyDinh    { get; set; }
        public decimal ? SoTienPhaiDong             { get; set; }
        public decimal ? SoTienDaDong               { get; set; }
        public decimal ? SoTienDu                   { get; set; }
        public string  ? TenNganHangThanhToanHocPhi { get; set; }
        public DateTime? ThoiDiemThanhToanHocPhi    { get; set; }
        public string  ? GhiChuBoSung               { get; set; }
        public long    ? MaThongTinHocPhiHocKyTruoc { get; set; }
        public long    ? MaHocKyNamHoc              { get; set; }
        public long    ? MaSinhVien                 { get; set; }

        public override Func<ReqBody_ThongTinHocPhi, Expression<Func<ThongTinHocPhi, bool>>> MatchExpression { get; set; } =
        (ReqBody_ThongTinHocPhi reqBody) => (ThongTinHocPhi model) =>
        (reqBody.MaThongTinHocPhi           == null ||
         reqBody.MaThongTinHocPhi           == model.MaThongTinHocPhi)           &&
        (reqBody.SoTienHocPhiTheoQuyDinh    == null ||
         reqBody.SoTienHocPhiTheoQuyDinh    == model.SoTienHocPhiTheoQuyDinh)    &&
        (reqBody.SoTienPhaiDong             == null ||
         reqBody.SoTienPhaiDong             == model.SoTienPhaiDong)             &&
        (reqBody.SoTienDaDong               == null ||
         reqBody.SoTienDaDong               == model.SoTienDaDong)               &&
        (reqBody.SoTienDu                   == null ||
         reqBody.SoTienDu                   == model.SoTienDu)                   &&
        (reqBody.TenNganHangThanhToanHocPhi == null ||
         reqBody.TenNganHangThanhToanHocPhi == model.TenNganHangThanhToanHocPhi) &&
        (reqBody.ThoiDiemThanhToanHocPhi    == null ||
         reqBody.ThoiDiemThanhToanHocPhi    == model.ThoiDiemThanhToanHocPhi)    &&
        (reqBody.GhiChuBoSung               == null ||
         reqBody.GhiChuBoSung               == model.GhiChuBoSung)               &&
        (reqBody.MaThongTinHocPhiHocKyTruoc == null ||
         reqBody.MaThongTinHocPhiHocKyTruoc == model.MaThongTinHocPhiHocKyTruoc) &&
        (reqBody.MaHocKyNamHoc              == null ||
         reqBody.MaHocKyNamHoc              == model.MaHocKyNamHoc)              &&
        (reqBody.MaSinhVien                 == null ||
         reqBody.MaSinhVien                 == model.MaSinhVien);
    }
}
