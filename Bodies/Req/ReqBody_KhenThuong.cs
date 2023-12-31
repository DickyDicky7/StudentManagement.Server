namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhenThuong : BaseReqBody<KhenThuong>
    {
        public long  ? MaKhenThuong      { get; set; }
        public string? XepLoaiKhenThuong { get; set; }
        public long  ? MaHocKyNamHoc     { get; set; }
        public long  ? MaSinhVien        { get; set; }
    }
}
