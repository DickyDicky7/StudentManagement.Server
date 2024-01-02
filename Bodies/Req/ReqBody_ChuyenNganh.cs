namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ChuyenNganh : BaseReqBody<ChuyenNganh>
    {
        public long  ?  MaChuyenNganh { get; set; }
        public string? TenChuyenNganh { get; set; }
        public long  ? MaKhoaDaoTao   { get; set; }

        public override Expression<Func<ChuyenNganh, bool>> MatchExpression()
        {
            return (ChuyenNganh model) =>
            (this. MaChuyenNganh == null ||
             this. MaChuyenNganh == model. MaChuyenNganh) &&
            (this.TenChuyenNganh == null ||
             this.TenChuyenNganh == model.TenChuyenNganh) &&
            (this.MaKhoaDaoTao   == null ||
             this.MaKhoaDaoTao   == model.MaKhoaDaoTao);
        }

        
    }

    public record class JustForInsertReqBody_ChuyenNganh : ReqBody_ChuyenNganh
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaChuyenNganh { get; set; }
    }

}
