namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_BuoiHoc : BaseReqBody<BuoiHoc>
    {
        public long  ? MaBuoiHoc         { get; set; }
        public long  ? MaHocPhan         { get; set; }
        public string? ThuHoc            { get; set; }
        public string? CaHoc             { get; set; }
        public string? SoTietHoc         { get; set; }
        public string? SoTuanHocCachNhau { get; set; }
        public string? MaPhongHoc        { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiHoc>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiHoc>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiHoc>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiHoc>>> chain = setter => setter;

            if (this.MaBuoiHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaBuoiHoc,
                        this  .MaBuoiHoc));

            if (this.MaHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocPhan,
                        this  .MaHocPhan));

            if (this.ThuHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.ThuHoc,
                        this  .ThuHoc));

            if (this.CaHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.CaHoc,
                        this  .CaHoc));

            if (this.SoTietHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTietHoc,
                        this  .SoTietHoc));

            if (this.SoTuanHocCachNhau != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTuanHocCachNhau,
                        this  .SoTuanHocCachNhau));

            if (this.MaPhongHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaPhongHoc,
                        this  .MaPhongHoc));

            return chain;
        }

        public override Expression<Func<BuoiHoc, bool>> MatchExpression()
        {
            return (model) =>
            (MaBuoiHoc         == null ||
             MaBuoiHoc         == model.MaBuoiHoc)         &&
            (MaHocPhan         == null ||
             MaHocPhan         == model.MaHocPhan)         &&
            (ThuHoc            == null ||
             ThuHoc            == model.ThuHoc)            &&
            (CaHoc             == null ||
             CaHoc             == model.CaHoc)             &&
            (SoTietHoc         == null ||
             SoTietHoc         == model.SoTietHoc)         &&
            (SoTuanHocCachNhau == null ||
             SoTuanHocCachNhau == model.SoTuanHocCachNhau) &&
            (MaPhongHoc        == null ||
             MaPhongHoc        == model.MaPhongHoc);
        }
    }

    public record class JustForInsertReqBody_BuoiHoc : ReqBody_BuoiHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBuoiHoc { get; set; }
    }
}
