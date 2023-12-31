namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HeDaoTao : BaseReqBody<HeDaoTao>
    {
        public long  ?  MaHeDaoTao { get; set; }
        public string? TenHeDaoTao { get; set; }

        public override bool Match(HeDaoTao model)
        {
            return (      this. MaHeDaoTao == null ||
            Object.Equals(this. MaHeDaoTao, model. MaHeDaoTao)) &&
            (             this.TenHeDaoTao == null ||
            Object.Equals(this.TenHeDaoTao, model.TenHeDaoTao));
        }
    }
}
