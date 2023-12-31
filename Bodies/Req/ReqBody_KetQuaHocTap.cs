namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaHocTap : BaseReqBody<KetQuaHocTap>
    {
        public long  ? MaKetQuaHocTap     { get; set; }
        public float ? DiemTrungBinhHocKy { get; set; }
        public string? XepLoaiHocTap      { get; set; }
        public long  ? MaHocKyNamHoc      { get; set; }
        public long  ? MaSinhVien         { get; set; }

        public override bool Match(KetQuaHocTap model)
        {
            return (      this.MaKetQuaHocTap     == null ||
            Object.Equals(this.MaKetQuaHocTap    , model.MaKetQuaHocTap))     &&
            (             this.DiemTrungBinhHocKy == null ||
            Object.Equals(this.DiemTrungBinhHocKy, model.DiemTrungBinhHocKy)) &&
            (             this.XepLoaiHocTap      == null ||
            Object.Equals(this.XepLoaiHocTap     , model.XepLoaiHocTap))      &&
            (             this.MaHocKyNamHoc      == null ||
            Object.Equals(this.MaHocKyNamHoc     , model.MaHocKyNamHoc))      &&
            (             this.MaSinhVien         == null ||
            Object.Equals(this.MaSinhVien        , model.MaSinhVien));
        }
    }
}
