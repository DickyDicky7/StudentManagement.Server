namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_HocPhan : BaseReqBody<ReqBody_HocPhan, HocPhan>
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

        public override Func<ReqBody_HocPhan, Expression<Func<HocPhan, bool>>> MatchExpression { get; set; } =
        (ReqBody_HocPhan reqBody) => (HocPhan model) =>
        (reqBody.MaHocPhan       == null ||
         reqBody.MaHocPhan       == model.MaHocPhan)       &&
        (reqBody.MaMonHoc        == null ||
         reqBody.MaMonHoc        == model.MaMonHoc)        &&
        (reqBody.MaHeDaoTao      == null ||
         reqBody.MaHeDaoTao      == model.MaHeDaoTao)      &&
        (reqBody.HinhThucThi     == null ||
         reqBody.HinhThucThi     == model.HinhThucThi)     &&
        (reqBody.LoaiHocPhan     == null ||
         reqBody.LoaiHocPhan     == model.LoaiHocPhan)     &&
        (reqBody.MaGiangVien     == null ||
         reqBody.MaGiangVien     == model.MaGiangVien)     &&
        (reqBody.SiSoSinhVien    == null ||
         reqBody.SiSoSinhVien    == model.SiSoSinhVien)    &&
        (reqBody.ThoiDiemBatDau  == null ||
         reqBody.ThoiDiemBatDau  == model.ThoiDiemBatDau)  &&
        (reqBody.ThoiDiemKetThuc == null ||
         reqBody.ThoiDiemKetThuc == model.ThoiDiemKetThuc) &&
        (reqBody.MaHocKyNamHoc   == null ||
         reqBody.MaHocKyNamHoc   == model.MaHocKyNamHoc)   &&
        (reqBody.GhiChu          == null ||
         reqBody.GhiChu          == model.GhiChu);
    }
}
