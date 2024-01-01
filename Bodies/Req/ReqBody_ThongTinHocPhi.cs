namespace StudentManagement.Server.Bodies.Req
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
            return (ThongTinHocPhi model) =>
            (this.MaThongTinHocPhi           == null ||
             this.MaThongTinHocPhi           == model.MaThongTinHocPhi)           &&
            (this.SoTienHocPhiTheoQuyDinh    == null ||
             this.SoTienHocPhiTheoQuyDinh    == model.SoTienHocPhiTheoQuyDinh)    &&
            (this.SoTienPhaiDong             == null ||
             this.SoTienPhaiDong             == model.SoTienPhaiDong)             &&
            (this.SoTienDaDong               == null ||
             this.SoTienDaDong               == model.SoTienDaDong)               &&
            (this.SoTienDu                   == null ||
             this.SoTienDu                   == model.SoTienDu)                   &&
            (this.TenNganHangThanhToanHocPhi == null ||
             this.TenNganHangThanhToanHocPhi == model.TenNganHangThanhToanHocPhi) &&
            (this.ThoiDiemThanhToanHocPhi    == null ||
             this.ThoiDiemThanhToanHocPhi    == model.ThoiDiemThanhToanHocPhi)    &&
            (this.GhiChuBoSung               == null ||
             this.GhiChuBoSung               == model.GhiChuBoSung)               &&
            (this.MaThongTinHocPhiHocKyTruoc == null ||
             this.MaThongTinHocPhiHocKyTruoc == model.MaThongTinHocPhiHocKyTruoc) &&
            (this.MaHocKyNamHoc              == null ||
             this.MaHocKyNamHoc              == model.MaHocKyNamHoc)              &&
            (this.MaSinhVien                 == null ||
             this.MaSinhVien                 == model.MaSinhVien);
        }
    }
}
