namespace StudentManagement.Server.Bodies.Req.Specific
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
            return (model) =>
            (MaBangDiemHocPhan == null ||
             MaBangDiemHocPhan == model.MaBangDiemHocPhan) &&
            (MaHocPhan         == null ||
             MaHocPhan         == model.MaHocPhan)         &&
            (MaSinhVien        == null ||
             MaSinhVien        == model.MaSinhVien)        &&
            (DiemQuaTrinh      == null ||
             DiemQuaTrinh      == model.DiemQuaTrinh)      &&
            (DiemGiuaKy        == null ||
             DiemGiuaKy        == model.DiemGiuaKy)        &&
            (DiemThucHanh      == null ||
             DiemThucHanh      == model.DiemThucHanh)      &&
            (DiemCuoiKy        == null ||
             DiemCuoiKy        == model.DiemCuoiKy);
        }
    }

    public record class JustForInsertReqBody_BangDiemHocPhan : ReqBody_BangDiemHocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBangDiemHocPhan { get; set; }
    }
}
