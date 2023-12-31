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

        public override bool Match(HocPhan model)
        {
            return (      this.MaHocPhan       == null ||
            Object.Equals(this.MaHocPhan      , model.MaHocPhan))       &&
            (             this.MaMonHoc        == null ||
            Object.Equals(this.MaMonHoc       , model.MaMonHoc))        &&
            (             this.MaHeDaoTao      == null ||
            Object.Equals(this.MaHeDaoTao     , model.MaHeDaoTao))      &&
            (             this.HinhThucThi     == null ||
            Object.Equals(this.HinhThucThi    , model.HinhThucThi))     &&
            (             this.LoaiHocPhan     == null ||
            Object.Equals(this.LoaiHocPhan    , model.LoaiHocPhan))     &&
            (             this.MaGiangVien     == null ||
            Object.Equals(this.MaGiangVien    , model.MaGiangVien))     &&
            (             this.SiSoSinhVien    == null ||
            Object.Equals(this.SiSoSinhVien   , model.SiSoSinhVien))    &&
            (             this.ThoiDiemBatDau  == null ||
            Object.Equals(this.ThoiDiemBatDau , model.ThoiDiemBatDau))  &&
            (             this.ThoiDiemKetThuc == null ||
            Object.Equals(this.ThoiDiemKetThuc, model.ThoiDiemKetThuc)) &&
            (             this.MaHocKyNamHoc   == null ||
            Object.Equals(this.MaHocKyNamHoc  , model.MaHocKyNamHoc))   &&
            (             this.GhiChu          == null ||
            Object.Equals(this.GhiChu         , model.GhiChu));
        }
    }
}
