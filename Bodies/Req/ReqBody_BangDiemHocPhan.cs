namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BangDiemHocPhan : BaseReqBody<BangDiemHocPhan>
    {
        public long ? MaBangDiemHocPhan { get; set; }
        public long ? MaHocPhan         { get; set; }
        public long ? MaSinhVien        { get; set; }
        public float? DiemQuaTrinh      { get; set; }
        public float? DiemGiuaKy        { get; set; }
        public float? DiemThucHanh      { get; set; }
        public float? DiemCuoiKy        { get; set; }
    }
}
