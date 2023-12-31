namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocKhoaDaoTao : BaseReqBody<GiangVienThuocKhoaDaoTao>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaKhoaDaoTao { get; set; }
    }
}
