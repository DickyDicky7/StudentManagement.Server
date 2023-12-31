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
    }
}
