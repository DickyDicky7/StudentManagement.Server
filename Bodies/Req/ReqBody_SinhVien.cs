namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_SinhVien : BaseReqBody<ReqBody_SinhVien, SinhVien>
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

        public override Func<ReqBody_SinhVien, Expression<Func<SinhVien, bool>>> MatchExpression { get; set; } =
        (ReqBody_SinhVien reqBody) => (SinhVien model) =>
        (reqBody.MaSinhVien                 == null ||
         reqBody.MaSinhVien                 == model.MaSinhVien)                 &&
        (reqBody.HoTenSinhVien              == null ||
         reqBody.HoTenSinhVien              == model.HoTenSinhVien)              &&
        (reqBody.MaKhoaHoc                  == null ||
         reqBody.MaKhoaHoc                  == model.MaKhoaHoc)                  &&
        (reqBody.MaChuyenNganh              == null ||
         reqBody.MaChuyenNganh              == model.MaChuyenNganh)              &&
        (reqBody.MaHeDaoTao                 == null ||
         reqBody.MaHeDaoTao                 == model.MaHeDaoTao)                 &&
        (reqBody.TinhTrangHocTap            == null ||
         reqBody.TinhTrangHocTap            == model.TinhTrangHocTap)            &&
        (reqBody.NgaySinh                   == null ||
         reqBody.NgaySinh                   == model.NgaySinh)                   &&
        (reqBody.GioiTinh                   == null ||
         reqBody.GioiTinh                   == model.GioiTinh)                   &&
        (reqBody.Email                      == null ||
         reqBody.Email                      == model.Email)                      &&
        (reqBody.EmailPassword              == null ||
         reqBody.EmailPassword              == model.EmailPassword)              &&
        (reqBody.Username                   == null ||
         reqBody.Username                   == model.Username)                   &&
        (reqBody.UsernamePassword           == null ||
         reqBody.UsernamePassword           == model.UsernamePassword)           &&
        (reqBody.SoTaiKhoanNganHangDinhDanh == null ||
         reqBody.SoTaiKhoanNganHangDinhDanh == model.SoTaiKhoanNganHangDinhDanh) &&
        (reqBody.AnhTheSinhVien             == null ||
         reqBody.AnhTheSinhVien             == model.AnhTheSinhVien);
    }
}
