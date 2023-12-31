namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HocPhan : BaseReqBody<HocPhan>
    {
        public long    ? MaHocPhan       { get; set; }
        public long    ? MaMonHoc        { get; set; }
        public long    ? MaHeDaoTao      { get; set; }
        public string  ? HinhThucThi     { get; set; }
        public string  ? LoaiHocPhan     { get; set; }
        public long    ? MaGiangVien     { get; set; }
        public short   ? SiSoSinhVien    { get; set; }
        public DateOnly? ThoiDiemBatDau  { get; set; }
        public DateOnly? ThoiDiemKetThuc { get; set; }
        public long    ? MaHocKyNamHoc   { get; set; }
        public string  ? GhiChu          { get; set; }
    }
}
