namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhenThuong : BaseReqBody<ReqBody_KhenThuong, KhenThuong>
    {
        public long  ? MaKhenThuong      { get; set; }
        public string? XepLoaiKhenThuong { get; set; }
        public long  ? MaHocKyNamHoc     { get; set; }
        public long  ? MaSinhVien        { get; set; }

        public override Func<ReqBody_KhenThuong, Expression<Func<KhenThuong, bool>>> MatchExpression { get; set; } =
        (ReqBody_KhenThuong reqBody) => (KhenThuong model) =>
        (reqBody.MaKhenThuong      == null ||
         reqBody.MaKhenThuong      == model.MaKhenThuong)      &&
        (reqBody.XepLoaiKhenThuong == null ||
         reqBody.XepLoaiKhenThuong == model.XepLoaiKhenThuong) &&
        (reqBody.MaHocKyNamHoc     == null ||
         reqBody.MaHocKyNamHoc     == model.MaHocKyNamHoc)     &&
        (reqBody.MaSinhVien        == null ||
         reqBody.MaSinhVien        == model.MaSinhVien);
    }
}
