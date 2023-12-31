namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_MonHoc : BaseReqBody<ReqBody_MonHoc, MonHoc>
    {
        public long    ?  MaMonHoc                 { get; set; }
        public string  ? TenMonHoc                 { get; set; }
        public bool    ? ConMoLop                  { get; set; }
        public string  ? LoaiMonHoc                { get; set; }
        public string[]? DanhSachMaMonHocTienQuyet { get; set; }
        public short   ? SoTinChiLyThuyet          { get; set; }
        public short   ? SoTinChiThucHanh          { get; set; }
        public string  ? TomTatMonHoc              { get; set; }

        public override Func<ReqBody_MonHoc, Expression<Func<MonHoc, bool>>> MatchExpression { get; set; } =
        (ReqBody_MonHoc reqBody) => (MonHoc model) =>
        (reqBody.MaMonHoc                  == null ||
         reqBody.MaMonHoc                  == model.MaMonHoc)                  &&
        (reqBody.TenMonHoc                 == null ||
         reqBody.TenMonHoc                 == model.TenMonHoc)                 &&
        (reqBody.ConMoLop                  == null ||
         reqBody.ConMoLop                  == model.ConMoLop)                  &&
        (reqBody.LoaiMonHoc                == null ||
         reqBody.LoaiMonHoc                == model.LoaiMonHoc)                &&
        (reqBody.DanhSachMaMonHocTienQuyet == null ||
         reqBody.DanhSachMaMonHocTienQuyet == model.DanhSachMaMonHocTienQuyet) &&
        (reqBody.SoTinChiLyThuyet          == null ||
         reqBody.SoTinChiLyThuyet          == model.SoTinChiLyThuyet)          &&
        (reqBody.SoTinChiThucHanh          == null ||
         reqBody.SoTinChiThucHanh          == model.SoTinChiThucHanh)          &&
        (reqBody.TomTatMonHoc              == null ||
         reqBody.TomTatMonHoc              == model.TomTatMonHoc);
    }
}
