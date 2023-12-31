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

        public override bool Match(ThongTinHocPhi model)
        {
            return       (this.MaThongTinHocPhi           == null ||
            Object.Equals(this.MaThongTinHocPhi          , model.MaThongTinHocPhi))           &&
                         (this.SoTienHocPhiTheoQuyDinh    == null ||
            Object.Equals(this.SoTienHocPhiTheoQuyDinh   , model.SoTienHocPhiTheoQuyDinh))    &&
                         (this.SoTienPhaiDong             == null ||
            Object.Equals(this.SoTienPhaiDong            , model.SoTienPhaiDong))             &&
                         (this.SoTienDaDong               == null ||
            Object.Equals(this.SoTienDaDong              , model.SoTienDaDong))               &&
                         (this.SoTienDu                   == null ||
            Object.Equals(this.SoTienDu                  , model.SoTienDu))                   &&
                         (this.TenNganHangThanhToanHocPhi == null ||
            Object.Equals(this.TenNganHangThanhToanHocPhi, model.TenNganHangThanhToanHocPhi)) &&
                         (this.ThoiDiemThanhToanHocPhi    == null ||
            Object.Equals(this.ThoiDiemThanhToanHocPhi   , model.ThoiDiemThanhToanHocPhi))    &&
                         (this.GhiChuBoSung               == null ||
            Object.Equals(this.GhiChuBoSung              , model.GhiChuBoSung))               &&
                         (this.MaThongTinHocPhiHocKyTruoc == null ||
            Object.Equals(this.MaThongTinHocPhiHocKyTruoc, model.MaThongTinHocPhiHocKyTruoc)) &&
                         (this.MaHocKyNamHoc              == null ||
            Object.Equals(this.MaHocKyNamHoc             , model.MaHocKyNamHoc))              &&
                         (this.MaSinhVien                 == null ||
            Object.Equals(this.MaSinhVien                , model.MaSinhVien));
        }
    }
}
