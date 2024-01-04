namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_MonHocThuocKhoaDaoTao : BaseReqBody<MonHocThuocKhoaDaoTao>
    {
        public long    ? MaMonHoc                  { get; set; }
        public string  ? TenMonHoc                 { get; set; }
        public bool    ? ConMoLop                  { get; set; }
        public string  ? LoaiMonHoc                { get; set; }
        public string[]? DanhSachMaMonHocTienQuyet { get; set; }
        public short   ? SoTinChiLyThuyet          { get; set; }
        public short   ? SoTinChiThucHanh          { get; set; }
        public string  ? TomTatMonHoc              { get; set; }
        public long    ? MaKhoaDaoTao              { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHocThuocKhoaDaoTao>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHocThuocKhoaDaoTao>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHocThuocKhoaDaoTao>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHocThuocKhoaDaoTao>>> chain = setter => setter;

            if (this.MaMonHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaMonHoc,
                        this  .MaMonHoc));

            if (this.TenMonHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenMonHoc,
                        this  .TenMonHoc));

            if (this.ConMoLop != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.ConMoLop,
                        this  .ConMoLop));

            if (this.LoaiMonHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.LoaiMonHoc,
                        this  .LoaiMonHoc));

            if (this.DanhSachMaMonHocTienQuyet != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DanhSachMaMonHocTienQuyet,
                        this  .DanhSachMaMonHocTienQuyet));

            if (this.SoTinChiLyThuyet != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTinChiLyThuyet,
                        this  .SoTinChiLyThuyet));

            if (this.SoTinChiThucHanh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTinChiThucHanh,
                        this  .SoTinChiThucHanh));

            if (this.TomTatMonHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TomTatMonHoc,
                        this  .TomTatMonHoc));

            if (this.MaKhoaDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhoaDaoTao,
                        this  .MaKhoaDaoTao));

            return chain;
        }

        public override Expression<Func<MonHocThuocKhoaDaoTao, bool>> MatchExpression()
        {
            return (model) =>
            (MaMonHoc                  == null ||
             MaMonHoc                  == model.MaMonHoc)                  &&
            (TenMonHoc                 == null ||
             TenMonHoc                 == model.TenMonHoc)                 &&
            (ConMoLop                  == null ||
             ConMoLop                  == model.ConMoLop)                  &&
            (LoaiMonHoc                == null ||
             LoaiMonHoc                == model.LoaiMonHoc)                &&
            (DanhSachMaMonHocTienQuyet == null ||
             DanhSachMaMonHocTienQuyet == model.DanhSachMaMonHocTienQuyet) &&
            (SoTinChiLyThuyet          == null ||
             SoTinChiLyThuyet          == model.SoTinChiLyThuyet)          &&
            (SoTinChiThucHanh          == null ||
             SoTinChiThucHanh          == model.SoTinChiThucHanh)          &&
            (TomTatMonHoc              == null ||
             TomTatMonHoc              == model.TomTatMonHoc)              &&
            (MaKhoaDaoTao              == null ||
             MaKhoaDaoTao              == model.MaKhoaDaoTao);
        }
    }

    public record class JustForInsertReqBody_MonHocThuocKhoaDaoTao : ReqBody_MonHocThuocKhoaDaoTao
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaMonHoc { get; set; }
    }
}
