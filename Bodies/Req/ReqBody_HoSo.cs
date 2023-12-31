namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HoSo : BaseReqBody<HoSo>
    {
        public long    ? MaHoSo          { get; set; }
        public bool    ? HoanThanh       { get; set; }
        public string  ? GhiChu          { get; set; }
        public string  ? LoaiHoSo        { get; set; }
        public string[]? DanhSachDinhKem { get; set; }
        public long    ? MaSinhVien      { get; set; }
    }
}
