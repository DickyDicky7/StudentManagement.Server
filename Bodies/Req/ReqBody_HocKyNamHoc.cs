namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HocKyNamHoc : BaseReqBody<HocKyNamHoc>
    {
        public long  ? MaHocKyNamHoc { get; set; }
        public string? TenHocKy      { get; set; }
        public string? TenNamHoc     { get; set; }

        public override Expression<Func<HocKyNamHoc, bool>> MatchExpression()
        {
            return (HocKyNamHoc model) =>
            (this.MaHocKyNamHoc == null ||
             this.MaHocKyNamHoc == model.MaHocKyNamHoc) &&
            (this.TenHocKy      == null ||
             this.TenHocKy      == model.TenHocKy)      &&
            (this.TenNamHoc     == null ||
             this.TenNamHoc     == model.TenNamHoc);
        }
    }
}
