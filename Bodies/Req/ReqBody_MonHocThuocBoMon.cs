namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_MonHocThuocBoMon : BaseReqBody<MonHocThuocBoMon>
    {
        public long    ?  MaMonHoc                 { get; set; }
        public string  ? TenMonHoc                 { get; set; }
        public bool    ? ConMoLop                  { get; set; }
        public string  ? LoaiMonHoc                { get; set; }
        public string[]? DanhSachMaMonHocTienQuyet { get; set; }
        public short   ? SoTinChiLyThuyet          { get; set; }
        public short   ? SoTinChiThucHanh          { get; set; }
        public string  ? TomTatMonHoc              { get; set; }
        public long    ? MaBoMon                   { get; set; }

        public override bool Match(MonHocThuocBoMon model)
        {
            return       (this.MaMonHoc                  == null ||
            Object.Equals(this.MaMonHoc                 , model.MaMonHoc))                  &&
                         (this.TenMonHoc                 == null ||
            Object.Equals(this.TenMonHoc                , model.TenMonHoc))                 &&
                         (this.ConMoLop                  == null ||
            Object.Equals(this.ConMoLop                 , model.ConMoLop))                  &&
                         (this.LoaiMonHoc                == null ||
            Object.Equals(this.LoaiMonHoc               , model.LoaiMonHoc))                &&
                         (this.DanhSachMaMonHocTienQuyet == null ||
            Object.Equals(this.DanhSachMaMonHocTienQuyet, model.DanhSachMaMonHocTienQuyet)) &&
                         (this.SoTinChiLyThuyet          == null ||
            Object.Equals(this.SoTinChiLyThuyet         , model.SoTinChiLyThuyet))          &&
                         (this.SoTinChiThucHanh          == null ||
            Object.Equals(this.SoTinChiThucHanh         , model.SoTinChiThucHanh))          &&
                         (this.TomTatMonHoc              == null ||
            Object.Equals(this.TomTatMonHoc             , model.TomTatMonHoc))              &&
                         (this.MaBoMon                   == null ||
            Object.Equals(this.MaBoMon                  , model.MaBoMon));
        }
    }
}
