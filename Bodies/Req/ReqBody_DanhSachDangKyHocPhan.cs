namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_DanhSachDangKyHocPhan : BaseReqBody<DanhSachDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocPhan               { get; set; }
        public bool? HocLaiHayHocCaiThien    { get; set; }
        public long? MaBangDiemHocPhan       { get; set; }

        public override Expression<Func<DanhSachDangKyHocPhan, bool>> MatchExpression()
        {
            return (DanhSachDangKyHocPhan model) =>
            (this.MaThongTinDangKyHocPhan == null ||
             this.MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan) &&
            (this.MaHocPhan               == null ||
             this.MaHocPhan               == model.MaHocPhan)               &&
            (this.HocLaiHayHocCaiThien    == null ||
             this.HocLaiHayHocCaiThien    == model.HocLaiHayHocCaiThien)    &&
            (this.MaBangDiemHocPhan       == null ||
             this.MaBangDiemHocPhan       == model.MaBangDiemHocPhan);
        }
    }
}
