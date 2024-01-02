namespace StudentManagement.Server.Bodies.Req.Specific
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
            return (model) =>
            (MaHoSo          == null ||
             MaHoSo          == model.MaHoSo)          &&
            (HoanThanh       == null ||
             HoanThanh       == model.HoanThanh)       &&
            (GhiChu          == null ||
             GhiChu          == model.GhiChu)          &&
            (LoaiHoSo        == null ||
             LoaiHoSo        == model.LoaiHoSo)        &&
            (DanhSachDinhKem == null ||
             DanhSachDinhKem == model.DanhSachDinhKem) &&
            (MaSinhVien      == null ||
             MaSinhVien      == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_HoSo : ReqBody_HoSo
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHoSo { get; set; }
    }
}
