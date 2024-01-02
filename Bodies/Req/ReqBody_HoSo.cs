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

        public override Expression<Func<HoSo, bool>> MatchExpression()
        {
            return (HoSo model) =>
            (this.MaHoSo          == null ||
             this.MaHoSo          == model.MaHoSo)          &&
            (this.HoanThanh       == null ||
             this.HoanThanh       == model.HoanThanh)       &&
            (this.GhiChu          == null ||
             this.GhiChu          == model.GhiChu)          &&
            (this.LoaiHoSo        == null ||
             this.LoaiHoSo        == model.LoaiHoSo)        &&
            (this.DanhSachDinhKem == null ||
             this.DanhSachDinhKem == model.DanhSachDinhKem) &&
            (this.MaSinhVien      == null ||
             this.MaSinhVien      == model.MaSinhVien);
        }

    }

    public record class JustForInsertReqBody_HoSo : ReqBody_HoSo
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHoSo { get; set; }
    }

}
