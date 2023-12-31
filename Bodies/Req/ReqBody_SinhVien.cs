namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_SinhVien : BaseReqBody<SinhVien>
    {
        public long    ? MaSinhVien                 { get; set; }
        public string  ? HoTenSinhVien              { get; set; }
        public long    ? MaKhoaHoc                  { get; set; }
        public long    ? MaChuyenNganh              { get; set; }
        public long    ? MaHeDaoTao                 { get; set; }
        public string  ? TinhTrangHocTap            { get; set; }
        public DateOnly? NgaySinh                   { get; set; }
        public string  ? GioiTinh                   { get; set; }
        public string  ? Email                      { get; set; }
        public string  ? EmailPassword              { get; set; }
        public string  ? Username                   { get; set; }
        public string  ? UsernamePassword           { get; set; }
        public string  ? SoTaiKhoanNganHangDinhDanh { get; set; }
        public string  ? AnhTheSinhVien             { get; set; }
    }
}
