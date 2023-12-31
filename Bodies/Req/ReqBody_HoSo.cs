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

        public override bool Match(HoSo model)
        {
            return (      this.MaHoSo          == null ||
            Object.Equals(this.MaHoSo         , model.MaHoSo))          &&
            (             this.HoanThanh       == null ||
            Object.Equals(this.HoanThanh      , model.HoanThanh))       &&
            (             this.GhiChu          == null ||
            Object.Equals(this.GhiChu         , model.GhiChu))          &&
            (             this.LoaiHoSo        == null ||
            Object.Equals(this.LoaiHoSo       , model.LoaiHoSo))        &&
            (             this.DanhSachDinhKem == null ||
            Object.Equals(this.DanhSachDinhKem, model.DanhSachDinhKem)) &&
            (             this.MaSinhVien      == null ||
            Object.Equals(this.MaSinhVien     , model.MaSinhVien));
        }
    }
}
