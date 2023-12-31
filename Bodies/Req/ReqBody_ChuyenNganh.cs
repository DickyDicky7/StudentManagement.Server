namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ChuyenNganh : BaseReqBody<ReqBody_ChuyenNganh, ChuyenNganh>
    {
        public long  ?  MaChuyenNganh { get; set; }
        public string? TenChuyenNganh { get; set; }
        public long  ? MaKhoaDaoTao   { get; set; }

        public override Func<ReqBody_ChuyenNganh, Expression<Func<ChuyenNganh, bool>>> MatchExpression { get; set; } =
        (ReqBody_ChuyenNganh reqBody) => (ChuyenNganh model) =>
        (reqBody. MaChuyenNganh == null ||
         reqBody. MaChuyenNganh == model. MaChuyenNganh) &&
        (reqBody.TenChuyenNganh == null ||
         reqBody.TenChuyenNganh == model.TenChuyenNganh) &&
        (reqBody.MaKhoaDaoTao   == null ||
         reqBody.MaKhoaDaoTao   == model.MaKhoaDaoTao);
    }
}
