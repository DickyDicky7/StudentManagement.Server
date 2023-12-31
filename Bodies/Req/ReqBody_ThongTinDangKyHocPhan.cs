namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinDangKyHocPhan : BaseReqBody<ReqBody_ThongTinDangKyHocPhan, ThongTinDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }

        public override Func<ReqBody_ThongTinDangKyHocPhan, Expression<Func<ThongTinDangKyHocPhan, bool>>> MatchExpression { get; set; } =
        (ReqBody_ThongTinDangKyHocPhan reqBody) => (ThongTinDangKyHocPhan model) =>
        (reqBody.MaThongTinDangKyHocPhan == null ||
         reqBody.MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan);
    }
}
