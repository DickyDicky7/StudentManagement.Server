namespace StudentManagement.Server.Bodies.Req.Specific
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
            return (model) =>
            (MaSinhVien                 == null ||
             MaSinhVien                 == model.MaSinhVien)                 &&
            (HoTenSinhVien              == null ||
             HoTenSinhVien              == model.HoTenSinhVien)              &&
            (MaKhoaHoc                  == null ||
             MaKhoaHoc                  == model.MaKhoaHoc)                  &&
            (MaChuyenNganh              == null ||
             MaChuyenNganh              == model.MaChuyenNganh)              &&
            (MaHeDaoTao                 == null ||
             MaHeDaoTao                 == model.MaHeDaoTao)                 &&
            (TinhTrangHocTap            == null ||
             TinhTrangHocTap            == model.TinhTrangHocTap)            &&
            (NgaySinh                   == null ||
             NgaySinh                   == model.NgaySinh)                   &&
            (GioiTinh                   == null ||
             GioiTinh                   == model.GioiTinh)                   &&
            (Email                      == null ||
             Email                      == model.Email)                      &&
            (EmailPassword              == null ||
             EmailPassword              == model.EmailPassword)              &&
            (Username                   == null ||
             Username                   == model.Username)                   &&
            (UsernamePassword           == null ||
             UsernamePassword           == model.UsernamePassword)           &&
            (SoTaiKhoanNganHangDinhDanh == null ||
             SoTaiKhoanNganHangDinhDanh == model.SoTaiKhoanNganHangDinhDanh) &&
            (AnhTheSinhVien             == null ||
             AnhTheSinhVien             == model.AnhTheSinhVien);
        }
    }

    public record class JustForInsertReqBody_SinhVien : ReqBody_SinhVien
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaSinhVien { get; set; }
    }
}
