namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_BoMon : BaseReqBody<BoMon>
    {
        public long  ?  MaBoMon { get; set; }
        public string? TenBoMon { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BoMon>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BoMon>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BoMon>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BoMon>>> chain = setter => setter;

            if (this.MaBoMon != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaBoMon,
                        this  .MaBoMon));

            if (this.TenBoMon != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenBoMon,
                        this  .TenBoMon));

            return chain;
        }

        public override Expression<Func<BoMon, bool>> MatchExpression()
        {
            return (model) =>
            ( MaBoMon == null ||
              MaBoMon == model. MaBoMon) &&
            (TenBoMon == null ||
             TenBoMon == model.TenBoMon);
        }
    }

    public record class JustForInsertReqBody_BoMon : ReqBody_BoMon
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBoMon { get; set; }
    }
}
