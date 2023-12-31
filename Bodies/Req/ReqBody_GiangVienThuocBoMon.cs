namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocBoMon : BaseReqBody<GiangVienThuocBoMon>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaBoMon      { get; set; }
    }
}
