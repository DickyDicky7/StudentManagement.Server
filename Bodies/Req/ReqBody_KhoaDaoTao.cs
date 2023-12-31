namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaDaoTao : BaseReqBody<KhoaDaoTao>
    {
        public long  ?  MaKhoaDaoTao { get; set; }
        public string? TenKhoaDaoTao { get; set; }

        public override bool Match(KhoaDaoTao model)
        {
            return (      this. MaKhoaDaoTao == null ||
            Object.Equals(this. MaKhoaDaoTao, model. MaKhoaDaoTao)) &&
            (             this.TenKhoaDaoTao == null ||
            Object.Equals(this.TenKhoaDaoTao, model.TenKhoaDaoTao));
        }
    }
}
