﻿namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_MonHoc : BaseReqBody<MonHoc>
    {
        public long    ? MaMonHoc                  { get; set; }
        public string  ? TenMonHoc                 { get; set; }
        public bool    ? ConMoLop                  { get; set; }
        public string  ? LoaiMonHoc                { get; set; }
        public string[]? DanhSachMaMonHocTienQuyet { get; set; }
        public short   ? SoTinChiLyThuyet          { get; set; }
        public short   ? SoTinChiThucHanh          { get; set; }
        public string  ? TomTatMonHoc              { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHoc>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHoc>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHoc>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<MonHoc>>> chain = setter => setter;

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

            return chain;
        }

        public override Expression<Func<MonHoc, bool>> MatchExpression()
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
             TomTatMonHoc              == model.TomTatMonHoc);
        }
    }

    public record class JustForInsertReqBody_MonHoc : ReqBody_MonHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaMonHoc { get; set; }
    }
}
