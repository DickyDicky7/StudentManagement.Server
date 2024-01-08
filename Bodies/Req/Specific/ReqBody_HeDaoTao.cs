namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_HeDaoTao : BaseReqBody<HeDaoTao>
    {
        public long  ?  MaHeDaoTao { get; set; }
        public string? TenHeDaoTao { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HeDaoTao>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HeDaoTao>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HeDaoTao>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HeDaoTao>>> chain = setter => setter;

            if (this.MaHeDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHeDaoTao,
                        this  .MaHeDaoTao));

            if (this.TenHeDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenHeDaoTao,
                        this  .TenHeDaoTao));

            return chain;
        }

        public override Expression<Func<HeDaoTao, bool>> MatchExpression()
        {
            return (model) =>
            ( MaHeDaoTao == null ||
              MaHeDaoTao == model. MaHeDaoTao) &&
            (TenHeDaoTao == null ||
             TenHeDaoTao == model.TenHeDaoTao);
        }
    }

    public record class JustForInsertReqBody_HeDaoTao : ReqBody_HeDaoTao
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHeDaoTao { get; set; }
    }
}
