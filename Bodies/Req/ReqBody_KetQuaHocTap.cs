namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaHocTap : BaseReqBody<ReqBody_KetQuaHocTap, KetQuaHocTap>
    {
        public long  ? MaKetQuaHocTap     { get; set; }
        public float ? DiemTrungBinhHocKy { get; set; }
        public string? XepLoaiHocTap      { get; set; }
        public long  ? MaHocKyNamHoc      { get; set; }
        public long  ? MaSinhVien         { get; set; }

        public override Func<ReqBody_KetQuaHocTap, Expression<Func<KetQuaHocTap, bool>>> MatchExpression { get; set; } =
        (ReqBody_KetQuaHocTap reqBody) => (KetQuaHocTap model) =>
        (reqBody.MaKetQuaHocTap     == null ||
         reqBody.MaKetQuaHocTap     == model.MaKetQuaHocTap)     &&
        (reqBody.DiemTrungBinhHocKy == null ||
         reqBody.DiemTrungBinhHocKy == model.DiemTrungBinhHocKy) &&
        (reqBody.XepLoaiHocTap      == null ||
         reqBody.XepLoaiHocTap      == model.XepLoaiHocTap)      &&
        (reqBody.MaHocKyNamHoc      == null ||
         reqBody.MaHocKyNamHoc      == model.MaHocKyNamHoc)      &&
        (reqBody.MaSinhVien         == null ||
         reqBody.MaSinhVien         == model.MaSinhVien);
    }
}
