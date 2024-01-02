namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_MonHocThuocKhoaDaoTao : BaseReqBody<MonHocThuocKhoaDaoTao>
    {
        public long    ? MaMonHoc                  { get; set; }
        public string  ? TenMonHoc                 { get; set; }
        public bool    ? ConMoLop                  { get; set; }
        public string  ? LoaiMonHoc                { get; set; }
        public string[]? DanhSachMaMonHocTienQuyet { get; set; }
        public short   ? SoTinChiLyThuyet          { get; set; }
        public short   ? SoTinChiThucHanh          { get; set; }
        public string  ? TomTatMonHoc              { get; set; }
        public long    ? MaKhoaDaoTao              { get; set; }

        public override Expression<Func<MonHocThuocKhoaDaoTao, bool>> MatchExpression()
        {
            return (model) =>
            (MaMonHoc                  == null ||
             MaMonHoc                  == model.MaMonHoc)                  &&
            (TenMonHoc                 == null ||
             TenMonHoc                 == model.TenMonHoc)                 &&
            (ConMoLop                  == null ||
             ConMoLop                  == model.ConMoLop)                  &&
            (LoaiMonHoc                == null ||
             LoaiMonHoc                == model.LoaiMonHoc)                &&
            (DanhSachMaMonHocTienQuyet == null ||
             DanhSachMaMonHocTienQuyet == model.DanhSachMaMonHocTienQuyet) &&
            (SoTinChiLyThuyet          == null ||
             SoTinChiLyThuyet          == model.SoTinChiLyThuyet)          &&
            (SoTinChiThucHanh          == null ||
             SoTinChiThucHanh          == model.SoTinChiThucHanh)          &&
            (TomTatMonHoc              == null ||
             TomTatMonHoc              == model.TomTatMonHoc)              &&
            (MaKhoaDaoTao              == null ||
             MaKhoaDaoTao              == model.MaKhoaDaoTao);
        }
    }

    public record class JustForInsertReqBody_MonHocThuocKhoaDaoTao : ReqBody_MonHocThuocKhoaDaoTao
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaMonHoc { get; set; }
    }
}
