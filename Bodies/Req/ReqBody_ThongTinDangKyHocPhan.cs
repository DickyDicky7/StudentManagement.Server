namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinDangKyHocPhan : BaseReqBody<ThongTinDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }

        public override bool Match(ThongTinDangKyHocPhan model)
        {
            return       (this.MaThongTinDangKyHocPhan == null ||
            Object.Equals(this.MaThongTinDangKyHocPhan, model.MaThongTinDangKyHocPhan));
        }
    }
}
