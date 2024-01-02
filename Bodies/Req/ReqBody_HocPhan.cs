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

        public override Expression<Func<HocPhan, bool>> MatchExpression()
        {
            return (HocPhan model) =>
            (this.MaHocPhan       == null ||
             this.MaHocPhan       == model.MaHocPhan)       &&
            (this.MaMonHoc        == null ||
             this.MaMonHoc        == model.MaMonHoc)        &&
            (this.MaHeDaoTao      == null ||
             this.MaHeDaoTao      == model.MaHeDaoTao)      &&
            (this.HinhThucThi     == null ||
             this.HinhThucThi     == model.HinhThucThi)     &&
            (this.LoaiHocPhan     == null ||
             this.LoaiHocPhan     == model.LoaiHocPhan)     &&
            (this.MaGiangVien     == null ||
             this.MaGiangVien     == model.MaGiangVien)     &&
            (this.SiSoSinhVien    == null ||
             this.SiSoSinhVien    == model.SiSoSinhVien)    &&
            (this.ThoiDiemBatDau  == null ||
             this.ThoiDiemBatDau  == model.ThoiDiemBatDau)  &&
            (this.ThoiDiemKetThuc == null ||
             this.ThoiDiemKetThuc == model.ThoiDiemKetThuc) &&
            (this.MaHocKyNamHoc   == null ||
             this.MaHocKyNamHoc   == model.MaHocKyNamHoc)   &&
            (this.GhiChu          == null ||
             this.GhiChu          == model.GhiChu);
        }

        
    }

    public record class JustForInsertReqBody_HocPhan : ReqBody_HocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHocPhan { get; set; }
    }

}
