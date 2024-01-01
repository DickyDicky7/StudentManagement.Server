namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BoMon : BaseReqBody<BoMon>
    {
        public long  ?  MaBoMon { get; set; }
        public string? TenBoMon { get; set; }

        public override Expression<Func<BoMon, bool>> MatchExpression()
        {
            return (BoMon model) =>
            (this. MaBoMon == null ||
             this. MaBoMon == model. MaBoMon) &&
            (this.TenBoMon == null ||
             this.TenBoMon == model.TenBoMon);
        }
    }
}
