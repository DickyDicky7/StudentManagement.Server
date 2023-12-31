namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinHocKyNamHoc : BaseReqBody<ThongTinHocKyNamHoc>
    {
        public long? MaThongTinHocKyNamHoc      { get; set; }
        public long? MaHocKyNamHoc              { get; set; }
        public long? MaSinhVien                 { get; set; }
        public long? MaThongTinDangKyHocPhan    { get; set; }
        public long? MaKetQuaHocTap             { get; set; }
        public long? MaKetQuaRenLuyen           { get; set; }
        public long? MaKhenThuong               { get; set; }
        public long? MaThongTinHocPhi           { get; set; }
        public long? MaThongTinHocKyNamHocTruoc { get; set; }
    }
}
