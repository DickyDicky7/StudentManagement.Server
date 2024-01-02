namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_HocKyNamHoc : BaseReqBody<HocKyNamHoc>
    {
        public long  ? MaHocKyNamHoc { get; set; }
        public string? TenHocKy      { get; set; }
        public string? TenNamHoc     { get; set; }

        public override Expression<Func<HocKyNamHoc, bool>> MatchExpression()
        {
            return (model) =>
            (MaHocKyNamHoc == null ||
             MaHocKyNamHoc == model.MaHocKyNamHoc) &&
            (TenHocKy      == null ||
             TenHocKy      == model.TenHocKy )     &&
            (TenNamHoc     == null ||
             TenNamHoc     == model.TenNamHoc);
        }
    }

    public record class JustForInsertReqBody_HocKyNamHoc : ReqBody_HocKyNamHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHocKyNamHoc { get; set; }
    }
}
