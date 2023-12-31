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

        public override bool Match(SinhVien model)
        {
            return       (this.MaSinhVien                 == null ||
            Object.Equals(this.MaSinhVien                , model.MaSinhVien))                 &&
                         (this.HoTenSinhVien              == null ||
            Object.Equals(this.HoTenSinhVien             , model.HoTenSinhVien))              &&
                         (this.MaKhoaHoc                  == null ||
            Object.Equals(this.MaKhoaHoc                 , model.MaKhoaHoc))                  &&
                         (this.MaChuyenNganh              == null ||
            Object.Equals(this.MaChuyenNganh             , model.MaChuyenNganh))              &&
                         (this.MaHeDaoTao                 == null ||
            Object.Equals(this.MaHeDaoTao                , model.MaHeDaoTao))                 &&
                         (this.TinhTrangHocTap            == null ||
            Object.Equals(this.TinhTrangHocTap           , model.TinhTrangHocTap))            &&
                         (this.NgaySinh                   == null ||
            Object.Equals(this.NgaySinh                  , model.NgaySinh))                   &&
                         (this.GioiTinh                   == null ||
            Object.Equals(this.GioiTinh                  , model.GioiTinh))                   &&
                         (this.Email                      == null ||
            Object.Equals(this.Email                     , model.Email))                      &&
                         (this.EmailPassword              == null ||
            Object.Equals(this.EmailPassword             , model.EmailPassword))              &&
                         (this.Username                   == null ||
            Object.Equals(this.Username                  , model.Username))                   &&
                         (this.UsernamePassword           == null ||
            Object.Equals(this.UsernamePassword          , model.UsernamePassword))           &&
                         (this.SoTaiKhoanNganHangDinhDanh == null ||
            Object.Equals(this.SoTaiKhoanNganHangDinhDanh, model.SoTaiKhoanNganHangDinhDanh)) &&
                         (this.AnhTheSinhVien             == null ||
            Object.Equals(this.AnhTheSinhVien            , model.AnhTheSinhVien));
        }
    }
}
