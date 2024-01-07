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
        public DateTime? ThoiDiemBatDau  { get; set; }
        public DateTime? ThoiDiemKetThuc { get; set; }
        public long    ? MaHocKyNamHoc   { get; set; }
        public string  ? GhiChu          { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocPhan>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocPhan>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocPhan>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HocPhan>>> chain = setter => setter;

            if (this.MaHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocPhan,
                        this  .MaHocPhan));

            if (this.MaMonHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaMonHoc,
                        this  .MaMonHoc));

            if (this.MaHeDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHeDaoTao,
                        this  .MaHeDaoTao));

            if (this.HinhThucThi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.HinhThucThi,
                        this  .HinhThucThi));

            if (this.LoaiHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.LoaiHocPhan,
                        this  .LoaiHocPhan));

            if (this.MaGiangVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaGiangVien,
                        this  .MaGiangVien));

            if (this.SiSoSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SiSoSinhVien,
                        this  .SiSoSinhVien));

            if (this.ThoiDiemBatDau != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.ThoiDiemBatDau,
                        this  .ThoiDiemBatDau));

            if (this.ThoiDiemKetThuc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.ThoiDiemKetThuc,
                        this  .ThoiDiemKetThuc));

            if (this.MaHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocKyNamHoc,
                        this  .MaHocKyNamHoc));

            if (this.GhiChu != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.GhiChu,
                        this  .GhiChu));

            return chain;
        }

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
