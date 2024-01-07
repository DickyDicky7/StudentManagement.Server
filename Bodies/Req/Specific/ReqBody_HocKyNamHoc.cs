namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_HocKyNamHoc : BaseReqBody<HocKyNamHoc>
    {
        public long  ? MaHocKyNamHoc { get; set; }
        public string? TenHocKy      { get; set; }
        public string? TenNamHoc     { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocKyNamHoc>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocKyNamHoc>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocKyNamHoc>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocKyNamHoc>>> chain = setter => setter;

            if (this.MaHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocKyNamHoc,
                        this  .MaHocKyNamHoc));

            if (this.TenHocKy != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenHocKy,
                        this  .TenHocKy));

            if (this.TenNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenNamHoc,
                        this  .TenNamHoc));

            return chain;
        }

        public override Expression<Func<HocKyNamHoc, bool>> MatchExpression()
        {
            return (model) =>
            (MaHocKyNamHoc == null ||
             MaHocKyNamHoc == model.MaHocKyNamHoc) &&
            (TenHocKy      == null ||
             TenHocKy      == model.TenHocKy )     &&
            (TenNamHoc     == null ||
             TenNamHoc     == model.TenNamHoc);
        }
    }

    public record class JustForInsertReqBody_HocKyNamHoc : ReqBody_HocKyNamHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHocKyNamHoc { get; set; }
    }
}
