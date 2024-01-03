namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KetQuaHocTap : BaseReqBody<KetQuaHocTap>
    {
        public long   ? MaKetQuaHocTap     { get; set; }
        public decimal? DiemTrungBinhHocKy { get; set; }
        public string ? XepLoaiHocTap      { get; set; }
        public long   ? MaHocKyNamHoc      { get; set; }
        public long   ? MaSinhVien         { get; set; }

        public override Expression<Func<KetQuaHocTap, bool>> MatchExpression()
        {
            return (model) =>
            (MaKetQuaHocTap     == null ||
             MaKetQuaHocTap     == model.MaKetQuaHocTap)     &&
            (DiemTrungBinhHocKy == null ||
             DiemTrungBinhHocKy == model.DiemTrungBinhHocKy) &&
            (XepLoaiHocTap      == null ||
             XepLoaiHocTap      == model.XepLoaiHocTap)      &&
            (MaHocKyNamHoc      == null ||
             MaHocKyNamHoc      == model.MaHocKyNamHoc)      &&
            (MaSinhVien         == null ||
             MaSinhVien         == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_KetQuaHocTap : ReqBody_KetQuaHocTap
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaKetQuaHocTap { get; set; }
    }
}
