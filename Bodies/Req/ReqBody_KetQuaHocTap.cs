namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaHocTap : BaseReqBody<KetQuaHocTap>
    {
        public long  ? MaKetQuaHocTap     { get; set; }
        public float ? DiemTrungBinhHocKy { get; set; }
        public string? XepLoaiHocTap      { get; set; }
        public long  ? MaHocKyNamHoc      { get; set; }
        public long  ? MaSinhVien         { get; set; }

        public override Expression<Func<KetQuaHocTap, bool>> MatchExpression()
        {
            return (KetQuaHocTap model) =>
            (this.MaKetQuaHocTap     == null ||
             this.MaKetQuaHocTap     == model.MaKetQuaHocTap)     &&
            (this.DiemTrungBinhHocKy == null ||
             this.DiemTrungBinhHocKy == model.DiemTrungBinhHocKy) &&
            (this.XepLoaiHocTap      == null ||
             this.XepLoaiHocTap      == model.XepLoaiHocTap)      &&
            (this.MaHocKyNamHoc      == null ||
             this.MaHocKyNamHoc      == model.MaHocKyNamHoc)      &&
            (this.MaSinhVien         == null ||
             this.MaSinhVien         == model.MaSinhVien);
        }
    }
}
