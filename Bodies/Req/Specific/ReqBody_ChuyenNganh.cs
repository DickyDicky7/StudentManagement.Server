namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ChuyenNganh : BaseReqBody<ChuyenNganh>
    {
        public long  ?  MaChuyenNganh { get; set; }
        public string? TenChuyenNganh { get; set; }
        public long  ? MaKhoaDaoTao   { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ChuyenNganh>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ChuyenNganh>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ChuyenNganh>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ChuyenNganh>>> chain = setter => setter;

            if (this.MaChuyenNganh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaChuyenNganh,
                        this  .MaChuyenNganh));

            if (this.TenChuyenNganh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenChuyenNganh,
                        this  .TenChuyenNganh));

            if (this.MaKhoaDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhoaDaoTao,
                        this  .MaKhoaDaoTao));

            return chain;
        }

        public override Expression<Func<ChuyenNganh, bool>> MatchExpression()
        {
            return (model) =>
            ( MaChuyenNganh == null ||
              MaChuyenNganh == model. MaChuyenNganh) &&
            (TenChuyenNganh == null ||
             TenChuyenNganh == model.TenChuyenNganh) &&
            (MaKhoaDaoTao   == null ||
             MaKhoaDaoTao   == model.MaKhoaDaoTao);
        }
    }

    public record class JustForInsertReqBody_ChuyenNganh : ReqBody_ChuyenNganh
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaChuyenNganh { get; set; }
    }
}
