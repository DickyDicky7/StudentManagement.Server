namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_DanhSachDangKyHocPhan : BaseReqBody<DanhSachDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocPhan               { get; set; }
        public bool? HocLaiHayHocCaiThien    { get; set; }
        public long? MaBangDiemHocPhan       { get; set; }

        public override Expression<Func<DanhSachDangKyHocPhan, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinDangKyHocPhan == null ||
             MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan) &&
            (MaHocPhan               == null ||
             MaHocPhan               == model.MaHocPhan)               &&
            (HocLaiHayHocCaiThien    == null ||
             HocLaiHayHocCaiThien    == model.HocLaiHayHocCaiThien)    &&
            (MaBangDiemHocPhan       == null ||
             MaBangDiemHocPhan       == model.MaBangDiemHocPhan);
        }
    }

    public record class JustForInsertReqBody_DanhSachDangKyHocPhan : ReqBody_DanhSachDangKyHocPhan
    {

    }
}
