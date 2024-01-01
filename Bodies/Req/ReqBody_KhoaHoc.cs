namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaHoc : BaseReqBody<KhoaHoc>
    {
        public long  ?  MaKhoaHoc          { get; set; }
        public string? TenKhoaHoc          { get; set; }
        public long  ? MaCoVanHocTap       { get; set; }
        public string? TenLopSinhHoatChung { get; set; }

        public override Expression<Func<KhoaHoc, bool>> MatchExpression()
        {
            return (KhoaHoc model) =>
            (this. MaKhoaHoc          == null ||
             this. MaKhoaHoc          == model. MaKhoaHoc)    &&
            (this.TenKhoaHoc          == null ||
             this.TenKhoaHoc          == model.TenKhoaHoc)    &&
            (this.MaCoVanHocTap       == null ||
             this.MaCoVanHocTap       == model.MaCoVanHocTap) &&
            (this.TenLopSinhHoatChung == null ||
             this.TenLopSinhHoatChung == model.TenLopSinhHoatChung);
        }
    }
}
