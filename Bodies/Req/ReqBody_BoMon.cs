namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BoMon : BaseReqBody<BoMon>
    {
        public long  ?  MaBoMon { get; set; }
        public string? TenBoMon { get; set; }

        public override bool Match(BoMon model)
        {
            return (      this. MaBoMon == null ||
            Object.Equals(this. MaBoMon, model. MaBoMon)) &&
            (             this.TenBoMon == null ||
            Object.Equals(this.TenBoMon, model.TenBoMon));
        }
    }
}
