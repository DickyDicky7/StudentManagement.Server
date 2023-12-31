namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BoMon : BaseReqBody<BoMon>
    {
        public long  ?  MaBoMon { get; set; }
        public string? TenBoMon { get; set; }
    }
}
