namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_HeDaoTao : BaseReqBody<HeDaoTao>
    {
        public long  ?  MaHeDaoTao { get; set; }
        public string? TenHeDaoTao { get; set; }

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
