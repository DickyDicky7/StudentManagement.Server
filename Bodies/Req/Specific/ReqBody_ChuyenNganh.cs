namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ChuyenNganh : BaseReqBody<ChuyenNganh>
    {
        public long  ?  MaChuyenNganh { get; set; }
        public string? TenChuyenNganh { get; set; }
        public long  ? MaKhoaDaoTao   { get; set; }

        public override Expression<Func<ChuyenNganh, bool>> MatchExpression()
        {
            return (model) =>
            ( MaChuyenNganh == null ||
              MaChuyenNganh == model. MaChuyenNganh) &&
            (TenChuyenNganh == null ||
             TenChuyenNganh == model.TenChuyenNganh) &&
            (MaKhoaDaoTao   == null ||
             MaKhoaDaoTao   == model.MaKhoaDaoTao);
        }
    }

    public record class JustForInsertReqBody_ChuyenNganh : ReqBody_ChuyenNganh
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaChuyenNganh { get; set; }
    }
}
