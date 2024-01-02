namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ThongTinHocPhi : BaseReqBody<ThongTinHocPhi>
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

        public override Expression<Func<ThongTinHocPhi, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinHocPhi           == null ||
             MaThongTinHocPhi           == model.MaThongTinHocPhi)           &&
            (SoTienHocPhiTheoQuyDinh    == null ||
             SoTienHocPhiTheoQuyDinh    == model.SoTienHocPhiTheoQuyDinh)    &&
            (SoTienPhaiDong             == null ||
             SoTienPhaiDong             == model.SoTienPhaiDong)             &&
            (SoTienDaDong               == null ||
             SoTienDaDong               == model.SoTienDaDong)               &&
            (SoTienDu                   == null ||
             SoTienDu                   == model.SoTienDu)                   &&
            (TenNganHangThanhToanHocPhi == null ||
             TenNganHangThanhToanHocPhi == model.TenNganHangThanhToanHocPhi) &&
            (ThoiDiemThanhToanHocPhi    == null ||
             ThoiDiemThanhToanHocPhi    == model.ThoiDiemThanhToanHocPhi)    &&
            (GhiChuBoSung               == null ||
             GhiChuBoSung               == model.GhiChuBoSung)               &&
            (MaThongTinHocPhiHocKyTruoc == null ||
             MaThongTinHocPhiHocKyTruoc == model.MaThongTinHocPhiHocKyTruoc) &&
            (MaHocKyNamHoc              == null ||
             MaHocKyNamHoc              == model.MaHocKyNamHoc)              &&
            (MaSinhVien                 == null ||
             MaSinhVien                 == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_ThongTinHocPhi : ReqBody_ThongTinHocPhi
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaThongTinHocPhi { get; set; }
    }
}
