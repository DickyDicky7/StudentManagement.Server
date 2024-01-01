namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_MonHocThuocKhoaDaoTao : BaseReqBody<MonHocThuocKhoaDaoTao>
    {
        public long    ?  MaMonHoc                 { get; set; }
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
            return (MonHocThuocKhoaDaoTao model) =>
            (this.MaMonHoc                  == null ||
             this.MaMonHoc                  == model.MaMonHoc)                  &&
            (this.TenMonHoc                 == null ||
             this.TenMonHoc                 == model.TenMonHoc)                 &&
            (this.ConMoLop                  == null ||
             this.ConMoLop                  == model.ConMoLop)                  &&
            (this.LoaiMonHoc                == null ||
             this.LoaiMonHoc                == model.LoaiMonHoc)                &&
            (this.DanhSachMaMonHocTienQuyet == null ||
             this.DanhSachMaMonHocTienQuyet == model.DanhSachMaMonHocTienQuyet) &&
            (this.SoTinChiLyThuyet          == null ||
             this.SoTinChiLyThuyet          == model.SoTinChiLyThuyet)          &&
            (this.SoTinChiThucHanh          == null ||
             this.SoTinChiThucHanh          == model.SoTinChiThucHanh)          &&
            (this.TomTatMonHoc              == null ||
             this.TomTatMonHoc              == model.TomTatMonHoc)              &&
            (this.MaKhoaDaoTao              == null ||
             this.MaKhoaDaoTao              == model.MaKhoaDaoTao);
        }
    }
}
