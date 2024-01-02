namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KhenThuong : BaseReqBody<KhenThuong>
    {
        public long  ? MaKhenThuong      { get; set; }
        public string? XepLoaiKhenThuong { get; set; }
        public long  ? MaHocKyNamHoc     { get; set; }
        public long  ? MaSinhVien        { get; set; }

        public override Expression<Func<KhenThuong, bool>> MatchExpression()
        {
            return (model) =>
            (MaKhenThuong      == null ||
             MaKhenThuong      == model.MaKhenThuong)      &&
            (XepLoaiKhenThuong == null ||
             XepLoaiKhenThuong == model.XepLoaiKhenThuong) &&
            (MaHocKyNamHoc     == null ||
             MaHocKyNamHoc     == model.MaHocKyNamHoc)     &&
            (MaSinhVien        == null ||
             MaSinhVien        == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_KhenThuong : ReqBody_KhenThuong
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaKhenThuong { get; set; }
    }
}
