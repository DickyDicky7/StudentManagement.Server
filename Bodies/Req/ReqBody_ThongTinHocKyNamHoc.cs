namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinHocKyNamHoc : BaseReqBody<ThongTinHocKyNamHoc>
    {
        public long? MaThongTinHocKyNamHoc      { get; set; }
        public long? MaHocKyNamHoc              { get; set; }
        public long? MaSinhVien                 { get; set; }
        public long? MaThongTinDangKyHocPhan    { get; set; }
        public long? MaKetQuaHocTap             { get; set; }
        public long? MaKetQuaRenLuyen           { get; set; }
        public long? MaKhenThuong               { get; set; }
        public long? MaThongTinHocPhi           { get; set; }
        public long? MaThongTinHocKyNamHocTruoc { get; set; }

        public override bool Match(ThongTinHocKyNamHoc model)
        {
            return       (this.MaThongTinHocKyNamHoc      == null ||
            Object.Equals(this.MaThongTinHocKyNamHoc     , model.MaThongTinHocKyNamHoc))   &&
                         (this.MaHocKyNamHoc              == null ||
            Object.Equals(this.MaHocKyNamHoc             , model.MaHocKyNamHoc))           &&
                         (this.MaSinhVien                 == null ||
            Object.Equals(this.MaSinhVien                , model.MaSinhVien))              &&
                         (this.MaThongTinDangKyHocPhan    == null ||
            Object.Equals(this.MaThongTinDangKyHocPhan   , model.MaThongTinDangKyHocPhan)) &&
                         (this.MaKetQuaHocTap             == null ||
            Object.Equals(this.MaKetQuaHocTap            , model.MaKetQuaHocTap))          &&
                         (this.MaKetQuaRenLuyen           == null ||
            Object.Equals(this.MaKetQuaRenLuyen          , model.MaKetQuaRenLuyen))        &&
                         (this.MaKhenThuong               == null ||
            Object.Equals(this.MaKhenThuong              , model.MaKhenThuong))            &&
                         (this.MaThongTinHocPhi           == null ||
            Object.Equals(this.MaThongTinHocPhi          , model.MaThongTinHocPhi))        &&
                         (this.MaThongTinHocKyNamHocTruoc == null ||
            Object.Equals(this.MaThongTinHocKyNamHocTruoc, model.MaThongTinHocKyNamHocTruoc));
        }
    }
}
