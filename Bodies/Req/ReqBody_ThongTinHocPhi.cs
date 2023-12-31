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
    }
}
