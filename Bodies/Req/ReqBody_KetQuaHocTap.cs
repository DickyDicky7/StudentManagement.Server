namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaHocTap : BaseReqBody<KetQuaHocTap>
    {
        public long  ? MaKetQuaHocTap     { get; set; }
        public float ? DiemTrungBinhHocKy { get; set; }
        public string? XepLoaiHocTap      { get; set; }
        public long  ? MaHocKyNamHoc      { get; set; }
        public long  ? MaSinhVien         { get; set; }
    }
}
