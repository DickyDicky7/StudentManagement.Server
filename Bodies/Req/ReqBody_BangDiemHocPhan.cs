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

        public override Expression<Func<BangDiemHocPhan, bool>> MatchExpression()
        {
            return (BangDiemHocPhan model) =>
            (this.MaBangDiemHocPhan == null ||
             this.MaBangDiemHocPhan == model.MaBangDiemHocPhan) &&
            (this.MaHocPhan         == null ||
             this.MaHocPhan         == model.MaHocPhan)         &&
            (this.MaSinhVien        == null ||
             this.MaSinhVien        == model.MaSinhVien)        &&
            (this.DiemQuaTrinh      == null ||
             this.DiemQuaTrinh      == model.DiemQuaTrinh)      &&
            (this.DiemGiuaKy        == null ||
             this.DiemGiuaKy        == model.DiemGiuaKy)        &&
            (this.DiemThucHanh      == null ||
             this.DiemThucHanh      == model.DiemThucHanh)      &&
            (this.DiemCuoiKy        == null ||
             this.DiemCuoiKy        == model.DiemCuoiKy);
        }

        
    }

    public record class JustForInsertReqBody_BangDiemHocPhan : ReqBody_BangDiemHocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBangDiemHocPhan { get; set; }
    }

}
