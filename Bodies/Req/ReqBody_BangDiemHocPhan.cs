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

        public override bool Match(BangDiemHocPhan model)
        {
            return (      this.MaBangDiemHocPhan == null ||
            Object.Equals(this.MaBangDiemHocPhan, model.MaBangDiemHocPhan)) &&
            (             this.MaHocPhan         == null ||
            Object.Equals(this.MaHocPhan        , model.MaHocPhan))         &&
            (             this.MaSinhVien        == null ||
            Object.Equals(this.MaSinhVien       , model.MaSinhVien))        &&
            (             this.DiemQuaTrinh      == null ||
            Object.Equals(this.DiemQuaTrinh     , model.DiemQuaTrinh))      &&
            (             this.DiemGiuaKy        == null ||
            Object.Equals(this.DiemGiuaKy       , model.DiemGiuaKy))        &&
            (             this.DiemThucHanh      == null ||
            Object.Equals(this.DiemThucHanh     , model.DiemThucHanh))      &&
            (             this.DiemCuoiKy        == null ||
            Object.Equals(this.DiemCuoiKy       , model.DiemCuoiKy));
        }
    }
}
