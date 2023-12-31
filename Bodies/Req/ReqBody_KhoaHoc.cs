namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaHoc : BaseReqBody<KhoaHoc>
    {
        public long  ?  MaKhoaHoc          { get; set; }
        public string? TenKhoaHoc          { get; set; }
        public long  ? MaCoVanHocTap       { get; set; }
        public string? TenLopSinhHoatChung { get; set; }
    }
}
