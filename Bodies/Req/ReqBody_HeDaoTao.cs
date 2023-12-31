namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HeDaoTao : BaseReqBody<ReqBody_HeDaoTao, HeDaoTao>
    {
        public long  ?  MaHeDaoTao { get; set; }
        public string? TenHeDaoTao { get; set; }

        public override Func<ReqBody_HeDaoTao, Expression<Func<HeDaoTao, bool>>> MatchExpression { get; set; } =
        (ReqBody_HeDaoTao reqBody) => (HeDaoTao model) =>
        (reqBody. MaHeDaoTao == null ||
         reqBody. MaHeDaoTao == model. MaHeDaoTao) &&
        (reqBody.TenHeDaoTao == null ||
         reqBody.TenHeDaoTao == model.TenHeDaoTao);
    }
}
