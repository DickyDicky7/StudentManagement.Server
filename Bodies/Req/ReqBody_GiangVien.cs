namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVien : BaseReqBody<GiangVien>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
    }
}
