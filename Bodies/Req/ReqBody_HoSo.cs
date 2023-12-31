namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HoSo : BaseReqBody<ReqBody_HoSo, HoSo>
    {
        public long    ? MaHoSo          { get; set; }
        public bool    ? HoanThanh       { get; set; }
        public string  ? GhiChu          { get; set; }
        public string  ? LoaiHoSo        { get; set; }
        public string[]? DanhSachDinhKem { get; set; }
        public long    ? MaSinhVien      { get; set; }

        public override Func<ReqBody_HoSo, Expression<Func<HoSo, bool>>> MatchExpression { get; set; } =
        (ReqBody_HoSo reqBody) => (HoSo model) =>
        (reqBody.MaHoSo          == null ||
         reqBody.MaHoSo          == model.MaHoSo)          &&
        (reqBody.HoanThanh       == null ||
         reqBody.HoanThanh       == model.HoanThanh)       &&
        (reqBody.GhiChu          == null ||
         reqBody.GhiChu          == model.GhiChu)          &&
        (reqBody.LoaiHoSo        == null ||
         reqBody.LoaiHoSo        == model.LoaiHoSo)        &&
        (reqBody.DanhSachDinhKem == null ||
         reqBody.DanhSachDinhKem == model.DanhSachDinhKem) &&
        (reqBody.MaSinhVien      == null ||
         reqBody.MaSinhVien      == model.MaSinhVien);
    }
}
