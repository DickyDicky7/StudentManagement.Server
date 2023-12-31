namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_DanhSachDangKyHocPhan : BaseReqBody<ReqBody_DanhSachDangKyHocPhan, DanhSachDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocPhan               { get; set; }
        public bool? HocLaiHayHocCaiThien    { get; set; }
        public long? MaBangDiemHocPhan       { get; set; }

        public override Func<ReqBody_DanhSachDangKyHocPhan, Expression<Func<DanhSachDangKyHocPhan, bool>>> MatchExpression { get; set; } =
        (ReqBody_DanhSachDangKyHocPhan reqBody) => (DanhSachDangKyHocPhan model) =>
        (reqBody.MaThongTinDangKyHocPhan == null ||
         reqBody.MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan) &&
        (reqBody.MaHocPhan               == null ||
         reqBody.MaHocPhan               == model.MaHocPhan)               &&
        (reqBody.HocLaiHayHocCaiThien    == null ||
         reqBody.HocLaiHayHocCaiThien    == model.HocLaiHayHocCaiThien)    &&
        (reqBody.MaBangDiemHocPhan       == null ||
         reqBody.MaBangDiemHocPhan       == model.MaBangDiemHocPhan);
    }
}
