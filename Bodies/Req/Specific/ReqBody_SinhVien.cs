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
        public DateTime? NgaySinh                   { get; set; }
        public string  ? GioiTinh                   { get; set; }
        public string  ? Email                      { get; set; }
        public string  ? EmailPassword              { get; set; }
        public string  ? Username                   { get; set; }
        public string  ? UsernamePassword           { get; set; }
        public string  ? SoTaiKhoanNganHangDinhDanh { get; set; }
        public string  ? AnhTheSinhVien             { get; set; }
        public DateTime? NgayNhapHoc                { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<SinhVien>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<SinhVien>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<SinhVien>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<SinhVien>>> chain = setter => setter;

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            if (this.HoTenSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.HoTenSinhVien,
                        this  .HoTenSinhVien));

            if (this.MaKhoaHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhoaHoc,
                        this  .MaKhoaHoc));

            if (this.MaChuyenNganh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaChuyenNganh,
                        this  .MaChuyenNganh));

            if (this.MaHeDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHeDaoTao,
                        this  .MaHeDaoTao));

            if (this.TinhTrangHocTap != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TinhTrangHocTap,
                        this  .TinhTrangHocTap));

            if (this.NgaySinh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.NgaySinh,
                        this  .NgaySinh));

            if (this.GioiTinh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.GioiTinh,
                        this  .GioiTinh));

            if (this.Email != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.Email,
                        this  .Email));

            if (this.EmailPassword != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.EmailPassword,
                        this  .EmailPassword));

            if (this.Username != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.Username,
                        this  .Username));

            if (this.UsernamePassword != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.UsernamePassword,
                        this  .UsernamePassword));

            if (this.SoTaiKhoanNganHangDinhDanh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTaiKhoanNganHangDinhDanh,
                        this  .SoTaiKhoanNganHangDinhDanh));

            if (this.AnhTheSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.AnhTheSinhVien,
                        this  .AnhTheSinhVien));

            if (this.NgayNhapHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.NgayNhapHoc,
                        this  .NgayNhapHoc));

            return chain;
        }

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
             AnhTheSinhVien             == model.AnhTheSinhVien)             &&
            (NgayNhapHoc                == null ||
             NgayNhapHoc                == model.NgayNhapHoc);
        }
    }

    public record class JustForInsertReqBody_SinhVien : ReqBody_SinhVien
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaSinhVien { get; set; }
    }
}
