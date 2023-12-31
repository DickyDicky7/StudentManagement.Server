namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ThongTinDangKyHocPhan : BaseReqBody<ThongTinDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
    }
}
