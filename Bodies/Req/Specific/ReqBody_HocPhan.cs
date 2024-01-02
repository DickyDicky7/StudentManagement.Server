namespace StudentManagement.Server.Bodies.Req.Specific
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

        public override Expression<Func<HocPhan, bool>> MatchExpression()
        {
            return (model) =>
            (MaHocPhan       == null ||
             MaHocPhan       == model.MaHocPhan)       &&
            (MaMonHoc        == null ||
             MaMonHoc        == model.MaMonHoc)        &&
            (MaHeDaoTao      == null ||
             MaHeDaoTao      == model.MaHeDaoTao)      &&
            (HinhThucThi     == null ||
             HinhThucThi     == model.HinhThucThi)     &&
            (LoaiHocPhan     == null ||
             LoaiHocPhan     == model.LoaiHocPhan)     &&
            (MaGiangVien     == null ||
             MaGiangVien     == model.MaGiangVien)     &&
            (SiSoSinhVien    == null ||
             SiSoSinhVien    == model.SiSoSinhVien)    &&
            (ThoiDiemBatDau  == null ||
             ThoiDiemBatDau  == model.ThoiDiemBatDau)  &&
            (ThoiDiemKetThuc == null ||
             ThoiDiemKetThuc == model.ThoiDiemKetThuc) &&
            (MaHocKyNamHoc   == null ||
             MaHocKyNamHoc   == model.MaHocKyNamHoc)   &&
            (GhiChu          == null ||
             GhiChu          == model.GhiChu);
        }
    }

    public record class JustForInsertReqBody_HocPhan : ReqBody_HocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHocPhan { get; set; }
    }
}
