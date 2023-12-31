namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BoMon : BaseReqBody<ReqBody_BoMon, BoMon>
    {
        public long  ?  MaBoMon { get; set; }
        public string? TenBoMon { get; set; }

        public override Func<ReqBody_BoMon, Expression<Func<BoMon, bool>>> MatchExpression { get; set; } =
        (ReqBody_BoMon reqBody) => (BoMon model) =>
        (reqBody. MaBoMon == null ||
         reqBody. MaBoMon == model. MaBoMon) &&
        (reqBody.TenBoMon == null ||
         reqBody.TenBoMon == model.TenBoMon);
    }
}
