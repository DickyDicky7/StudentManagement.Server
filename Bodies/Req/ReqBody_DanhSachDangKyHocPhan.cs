namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_DanhSachDangKyHocPhan : BaseReqBody<DanhSachDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocPhan               { get; set; }
        public bool? HocLaiHayHocCaiThien    { get; set; }
        public long? MaBangDiemHocPhan       { get; set; }

        public override bool Match(DanhSachDangKyHocPhan model)
        {
            return (      this.MaThongTinDangKyHocPhan == null ||
            Object.Equals(this.MaThongTinDangKyHocPhan, model.MaThongTinDangKyHocPhan)) &&
            (             this.MaHocPhan               == null ||
            Object.Equals(this.MaHocPhan              , model.MaHocPhan))               &&
            (             this.HocLaiHayHocCaiThien    == null ||
            Object.Equals(this.HocLaiHayHocCaiThien   , model.HocLaiHayHocCaiThien))    &&
            (             this.MaBangDiemHocPhan       == null ||
            Object.Equals(this.MaBangDiemHocPhan      , model.MaBangDiemHocPhan));
        }
    }
}
