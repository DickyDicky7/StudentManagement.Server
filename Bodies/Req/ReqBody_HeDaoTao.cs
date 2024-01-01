namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HeDaoTao : BaseReqBody<HeDaoTao>
    {
        public long  ?  MaHeDaoTao { get; set; }
        public string? TenHeDaoTao { get; set; }

        public override Expression<Func<HeDaoTao, bool>> MatchExpression()
        {
            return (HeDaoTao model) =>
            (this. MaHeDaoTao == null ||
             this. MaHeDaoTao == model. MaHeDaoTao) &&
            (this.TenHeDaoTao == null ||
             this.TenHeDaoTao == model.TenHeDaoTao);
        }
    }
}
