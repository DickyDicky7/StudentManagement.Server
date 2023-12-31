namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HocKyNamHoc : BaseReqBody<HocKyNamHoc>
    {
        public long  ? MaHocKyNamHoc { get; set; }
        public string? TenHocKy      { get; set; }
        public string? TenNamHoc     { get; set; }
    }
}
