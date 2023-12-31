namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_DanhSachDangKyHocPhan : BaseReqBody<DanhSachDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocPhan               { get; set; }
        public bool? HocLaiHayHocCaiThien    { get; set; }
        public long? MaBangDiemHocPhan       { get; set; }
    }
}
