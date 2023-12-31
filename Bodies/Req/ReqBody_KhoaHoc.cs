namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaHoc : BaseReqBody<KhoaHoc>
    {
        public long  ?  MaKhoaHoc          { get; set; }
        public string? TenKhoaHoc          { get; set; }
        public long  ? MaCoVanHocTap       { get; set; }
        public string? TenLopSinhHoatChung { get; set; }

        public override bool Match(KhoaHoc model)
        {
            return       (this. MaKhoaHoc          == null ||
            Object.Equals(this. MaKhoaHoc         , model. MaKhoaHoc))    &&
                         (this.TenKhoaHoc          == null ||
            Object.Equals(this.TenKhoaHoc         , model.TenKhoaHoc))    &&
                         (this.MaCoVanHocTap       == null ||
            Object.Equals(this.MaCoVanHocTap      , model.MaCoVanHocTap)) &&
                         (this.TenLopSinhHoatChung == null ||
            Object.Equals(this.TenLopSinhHoatChung, model.TenLopSinhHoatChung));
        }
    }
}
