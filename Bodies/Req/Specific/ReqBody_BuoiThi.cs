namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_BuoiThi : BaseReqBody<BuoiThi>
    {
        public long    ? MaBuoiThi  { get; set; }
        public long    ? MaHocPhan  { get; set; }
        public DateTime? NgayThi    { get; set; }
        public string  ? MaPhongThi { get; set; }
        public string  ? ThuThi     { get; set; }
        public string  ? CaThi      { get; set; }
        public string  ? GhiChu     { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiThi>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiThi>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiThi>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BuoiThi>>> chain = setter => setter;

            if (this.MaBuoiThi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaBuoiThi,
                        this  .MaBuoiThi));

            if (this.MaHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocPhan,
                        this  .MaHocPhan));

            if (this.NgayThi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.NgayThi,
                        this  .NgayThi));

            if (this.MaPhongThi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaPhongThi,
                        this  .MaPhongThi));

            if (this.ThuThi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.ThuThi,
                        this  .ThuThi));

            if (this.CaThi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.CaThi,
                        this  .CaThi));

            if (this.GhiChu != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.GhiChu,
                        this  .GhiChu));

            return chain;

        }

        public override Expression<Func<BuoiThi, bool>> MatchExpression()
        {
            return (model) =>
            (MaBuoiThi  == null ||
             MaBuoiThi  == model.MaBuoiThi)  &&
            (MaHocPhan  == null ||
             MaHocPhan  == model.MaHocPhan)  &&
            (NgayThi    == null ||
             NgayThi    == model.NgayThi)    &&
            (MaPhongThi == null ||
             MaPhongThi == model.MaPhongThi) &&
            (ThuThi     == null ||
             ThuThi     == model.ThuThi)     &&
            (CaThi      == null ||
             CaThi      == model.CaThi)      &&
            (GhiChu     == null ||
             GhiChu     == model.GhiChu);
        }
    }

    public record class JustForInsertReqBody_BuoiThi : ReqBody_BuoiThi
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBuoiThi { get; set; }
    }
}
