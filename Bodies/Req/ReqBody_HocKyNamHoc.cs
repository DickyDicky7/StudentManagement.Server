namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HocKyNamHoc : BaseReqBody<ReqBody_HocKyNamHoc, HocKyNamHoc>
    {
        public long  ? MaHocKyNamHoc { get; set; }
        public string? TenHocKy      { get; set; }
        public string? TenNamHoc     { get; set; }

        public override Func<ReqBody_HocKyNamHoc, Expression<Func<HocKyNamHoc, bool>>> MatchExpression { get; set; } =
        (ReqBody_HocKyNamHoc reqBody) => (HocKyNamHoc model) =>
        (reqBody.MaHocKyNamHoc == null ||
         reqBody.MaHocKyNamHoc == model.MaHocKyNamHoc) &&
        (reqBody.TenHocKy      == null ||
         reqBody.TenHocKy      == model.TenHocKy)      &&
        (reqBody.TenNamHoc     == null ||
         reqBody.TenNamHoc     == model.TenNamHoc);
    }
}
