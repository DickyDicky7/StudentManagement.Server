namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaDaoTao : BaseReqBody<ReqBody_KhoaDaoTao, KhoaDaoTao>
    {
        public long  ?  MaKhoaDaoTao { get; set; }
        public string? TenKhoaDaoTao { get; set; }

        public override Func<ReqBody_KhoaDaoTao, Expression<Func<KhoaDaoTao, bool>>> MatchExpression { get; set; } =
        (ReqBody_KhoaDaoTao reqBody) => (KhoaDaoTao model) =>
        (reqBody. MaKhoaDaoTao == null ||
         reqBody. MaKhoaDaoTao == model. MaKhoaDaoTao) &&
        (reqBody.TenKhoaDaoTao == null ||
         reqBody.TenKhoaDaoTao == model.TenKhoaDaoTao);
    }
}
