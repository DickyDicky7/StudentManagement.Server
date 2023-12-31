namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HeDaoTao : BaseReqBody<HeDaoTao>
    {
        public long  ?  MaHeDaoTao { get; set; }
        public string? TenHeDaoTao { get; set; }
    }
}
