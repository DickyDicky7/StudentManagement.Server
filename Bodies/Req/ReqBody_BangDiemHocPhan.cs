namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BangDiemHocPhan : BaseReqBody<ReqBody_BangDiemHocPhan, BangDiemHocPhan>
    {
        public long ? MaBangDiemHocPhan { get; set; }
        public long ? MaHocPhan         { get; set; }
        public long ? MaSinhVien        { get; set; }
        public float? DiemQuaTrinh      { get; set; }
        public float? DiemGiuaKy        { get; set; }
        public float? DiemThucHanh      { get; set; }
        public float? DiemCuoiKy        { get; set; }

        public override Func<ReqBody_BangDiemHocPhan, Expression<Func<BangDiemHocPhan, bool>>> MatchExpression { get; set; } =
        (ReqBody_BangDiemHocPhan reqBody) => (BangDiemHocPhan model) =>
        (reqBody.MaBangDiemHocPhan == null ||
         reqBody.MaBangDiemHocPhan == model.MaBangDiemHocPhan) &&
        (reqBody.MaHocPhan         == null ||
         reqBody.MaHocPhan         == model.MaHocPhan)         &&
        (reqBody.MaSinhVien        == null ||
         reqBody.MaSinhVien        == model.MaSinhVien)        &&
        (reqBody.DiemQuaTrinh      == null ||
         reqBody.DiemQuaTrinh      == model.DiemQuaTrinh)      &&
        (reqBody.DiemGiuaKy        == null ||
         reqBody.DiemGiuaKy        == model.DiemGiuaKy)        &&
        (reqBody.DiemThucHanh      == null ||
         reqBody.DiemThucHanh      == model.DiemThucHanh)      &&
        (reqBody.DiemCuoiKy        == null ||
         reqBody.DiemCuoiKy        == model.DiemCuoiKy);
    }
}
