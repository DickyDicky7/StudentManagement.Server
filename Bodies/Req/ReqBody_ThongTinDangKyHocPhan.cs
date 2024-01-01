namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinDangKyHocPhan : BaseReqBody<ThongTinDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }

        public override Expression<Func<ThongTinDangKyHocPhan, bool>> MatchExpression()
        {
            return (ThongTinDangKyHocPhan model) =>
            (this.MaThongTinDangKyHocPhan == null ||
             this.MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan);
        }
    }
}
