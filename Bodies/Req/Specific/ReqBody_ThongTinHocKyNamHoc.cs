namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ThongTinHocKyNamHoc : BaseReqBody<ThongTinHocKyNamHoc>
    {
        public long? MaThongTinHocKyNamHoc      { get; set; }
        public long? MaHocKyNamHoc              { get; set; }
        public long? MaSinhVien                 { get; set; }
        public long? MaThongTinDangKyHocPhan    { get; set; }
        public long? MaKetQuaHocTap             { get; set; }
        public long? MaKetQuaRenLuyen           { get; set; }
        public long? MaKhenThuong               { get; set; }
        public long? MaThongTinHocPhi           { get; set; }
        public long? MaThongTinHocKyNamHocTruoc { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocKyNamHoc>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocKyNamHoc>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocKyNamHoc>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocKyNamHoc>>> chain = setter => setter;

            if (this.MaThongTinHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinHocKyNamHoc,
                        this  .MaThongTinHocKyNamHoc));

            if (this.MaHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocKyNamHoc,
                        this  .MaHocKyNamHoc));

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            if (this.MaThongTinDangKyHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinDangKyHocPhan,
                        this  .MaThongTinDangKyHocPhan));

            if (this.MaKetQuaHocTap != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKetQuaHocTap,
                        this  .MaKetQuaHocTap));

            if (this.MaKetQuaRenLuyen != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKetQuaRenLuyen,
                        this  .MaKetQuaRenLuyen));

            if (this.MaKhenThuong != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhenThuong,
                        this  .MaKhenThuong));

            if (this.MaThongTinHocPhi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinHocPhi,
                        this  .MaThongTinHocPhi));

            if (this.MaThongTinHocKyNamHocTruoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinHocKyNamHocTruoc,
                        this  .MaThongTinHocKyNamHocTruoc));

            return chain;
        }

        public override Expression<Func<ThongTinHocKyNamHoc, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinHocKyNamHoc      == null ||
             MaThongTinHocKyNamHoc      == model.MaThongTinHocKyNamHoc)   &&
            (MaHocKyNamHoc              == null ||
             MaHocKyNamHoc              == model.MaHocKyNamHoc)           &&
            (MaSinhVien                 == null ||
             MaSinhVien                 == model.MaSinhVien)              &&
            (MaThongTinDangKyHocPhan    == null ||
             MaThongTinDangKyHocPhan    == model.MaThongTinDangKyHocPhan) &&
            (MaKetQuaHocTap             == null ||
             MaKetQuaHocTap             == model.MaKetQuaHocTap)          &&
            (MaKetQuaRenLuyen           == null ||
             MaKetQuaRenLuyen           == model.MaKetQuaRenLuyen)        &&
            (MaKhenThuong               == null ||
             MaKhenThuong               == model.MaKhenThuong)            &&
            (MaThongTinHocPhi           == null ||
             MaThongTinHocPhi           == model.MaThongTinHocPhi)        &&
            (MaThongTinHocKyNamHocTruoc == null ||
             MaThongTinHocKyNamHocTruoc == model.MaThongTinHocKyNamHocTruoc);
        }
    }

    public record class JustForInsertReqBody_ThongTinHocKyNamHoc : ReqBody_ThongTinHocKyNamHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaThongTinHocKyNamHoc { get; set; }
    }
}
