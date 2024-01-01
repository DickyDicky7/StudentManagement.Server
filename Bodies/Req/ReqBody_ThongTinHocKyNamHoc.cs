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

        public override Expression<Func<ThongTinHocKyNamHoc, bool>> MatchExpression()
        {
            return (ThongTinHocKyNamHoc model) =>
            (this.MaThongTinHocKyNamHoc      == null ||
             this.MaThongTinHocKyNamHoc      == model.MaThongTinHocKyNamHoc)   &&
            (this.MaHocKyNamHoc              == null ||
             this.MaHocKyNamHoc              == model.MaHocKyNamHoc)           &&
            (this.MaSinhVien                 == null ||
             this.MaSinhVien                 == model.MaSinhVien)              &&
            (this.MaThongTinDangKyHocPhan    == null ||
             this.MaThongTinDangKyHocPhan    == model.MaThongTinDangKyHocPhan) &&
            (this.MaKetQuaHocTap             == null ||
             this.MaKetQuaHocTap             == model.MaKetQuaHocTap)          &&
            (this.MaKetQuaRenLuyen           == null ||
             this.MaKetQuaRenLuyen           == model.MaKetQuaRenLuyen)        &&
            (this.MaKhenThuong               == null ||
             this.MaKhenThuong               == model.MaKhenThuong)            &&
            (this.MaThongTinHocPhi           == null ||
             this.MaThongTinHocPhi           == model.MaThongTinHocPhi)        &&
            (this.MaThongTinHocKyNamHocTruoc == null ||
             this.MaThongTinHocKyNamHocTruoc == model.MaThongTinHocKyNamHocTruoc);
        }
    }
}
