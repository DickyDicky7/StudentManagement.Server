namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaDaoTao : BaseReqBody<KhoaDaoTao>
    {
        public long  ?  MaKhoaDaoTao { get; set; }
        public string? TenKhoaDaoTao { get; set; }

        public override Expression<Func<KhoaDaoTao, bool>> MatchExpression()
        {
            return (KhoaDaoTao model) =>
            (this. MaKhoaDaoTao == null ||
             this. MaKhoaDaoTao == model. MaKhoaDaoTao) &&
            (this.TenKhoaDaoTao == null ||
             this.TenKhoaDaoTao == model.TenKhoaDaoTao);
        }
    }
}
