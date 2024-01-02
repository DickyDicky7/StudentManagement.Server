namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ThongTinDangKyHocPhan : BaseReqBody<ThongTinDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }

        public override Expression<Func<ThongTinDangKyHocPhan, bool>> MatchExpression()
        {
            return (model) =>
            MaThongTinDangKyHocPhan == null ||
            MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan;
        }
    }

    public record class JustForInsertReqBody_ThongTinDangKyHocPhan : ReqBody_ThongTinDangKyHocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaThongTinDangKyHocPhan { get; set; }
    }
}
