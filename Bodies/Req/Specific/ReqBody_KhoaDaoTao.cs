namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KhoaDaoTao : BaseReqBody<KhoaDaoTao>
    {
        public long  ?  MaKhoaDaoTao { get; set; }
        public string? TenKhoaDaoTao { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaDaoTao>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaDaoTao>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaDaoTao>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaDaoTao>>> chain = setter => setter;

            if (this.MaKhoaDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhoaDaoTao,
                        this  .MaKhoaDaoTao));

            if (this.TenKhoaDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenKhoaDaoTao,
                        this  .TenKhoaDaoTao));

            return chain;
        }

        public override Expression<Func<KhoaDaoTao, bool>> MatchExpression()
        {
            return (model) =>
            ( MaKhoaDaoTao == null ||
              MaKhoaDaoTao == model. MaKhoaDaoTao) &&
            (TenKhoaDaoTao == null ||
             TenKhoaDaoTao == model.TenKhoaDaoTao);
        }
    }

    public record class JustForInsertReqBody_KhoaDaoTao : ReqBody_KhoaDaoTao
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaKhoaDaoTao { get; set; }
    }
}
