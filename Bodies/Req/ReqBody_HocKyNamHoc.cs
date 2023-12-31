namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HocKyNamHoc : BaseReqBody<HocKyNamHoc>
    {
        public long  ? MaHocKyNamHoc { get; set; }
        public string? TenHocKy      { get; set; }
        public string? TenNamHoc     { get; set; }

        public override bool Match(HocKyNamHoc model)
        {
            return (      this.MaHocKyNamHoc == null ||
            Object.Equals(this.MaHocKyNamHoc, model.MaHocKyNamHoc)) &&
            (             this.TenHocKy      == null ||
            Object.Equals(this.TenHocKy     , model.TenHocKy))      &&
            (             this.TenNamHoc     == null ||
            Object.Equals(this.TenNamHoc    , model.TenNamHoc));
        }
    }
}
