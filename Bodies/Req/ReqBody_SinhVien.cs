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

        public override Expression<Func<SinhVien, bool>> MatchExpression()
        {
            return (SinhVien model) =>
            (this.MaSinhVien                 == null ||
             this.MaSinhVien                 == model.MaSinhVien)                 &&
            (this.HoTenSinhVien              == null ||
             this.HoTenSinhVien              == model.HoTenSinhVien)              &&
            (this.MaKhoaHoc                  == null ||
             this.MaKhoaHoc                  == model.MaKhoaHoc)                  &&
            (this.MaChuyenNganh              == null ||
             this.MaChuyenNganh              == model.MaChuyenNganh)              &&
            (this.MaHeDaoTao                 == null ||
             this.MaHeDaoTao                 == model.MaHeDaoTao)                 &&
            (this.TinhTrangHocTap            == null ||
             this.TinhTrangHocTap            == model.TinhTrangHocTap)            &&
            (this.NgaySinh                   == null ||
             this.NgaySinh                   == model.NgaySinh)                   &&
            (this.GioiTinh                   == null ||
             this.GioiTinh                   == model.GioiTinh)                   &&
            (this.Email                      == null ||
             this.Email                      == model.Email)                      &&
            (this.EmailPassword              == null ||
             this.EmailPassword              == model.EmailPassword)              &&
            (this.Username                   == null ||
             this.Username                   == model.Username)                   &&
            (this.UsernamePassword           == null ||
             this.UsernamePassword           == model.UsernamePassword)           &&
            (this.SoTaiKhoanNganHangDinhDanh == null ||
             this.SoTaiKhoanNganHangDinhDanh == model.SoTaiKhoanNganHangDinhDanh) &&
            (this.AnhTheSinhVien             == null ||
             this.AnhTheSinhVien             == model.AnhTheSinhVien);
        }
    }
}
