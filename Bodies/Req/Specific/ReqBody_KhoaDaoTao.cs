namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KhoaDaoTao : BaseReqBody<KhoaDaoTao>
    {
        public long  ?  MaKhoaDaoTao { get; set; }
        public string? TenKhoaDaoTao { get; set; }

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
