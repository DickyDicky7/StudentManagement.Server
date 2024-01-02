namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhenThuong : BaseReqBody<KhenThuong>
    {
        public long  ? MaKhenThuong      { get; set; }
        public string? XepLoaiKhenThuong { get; set; }
        public long  ? MaHocKyNamHoc     { get; set; }
        public long  ? MaSinhVien        { get; set; }

        public override Expression<Func<KhenThuong, bool>> MatchExpression()
        {
            return (KhenThuong model) =>
            (this.MaKhenThuong      == null ||
             this.MaKhenThuong      == model.MaKhenThuong)      &&
            (this.XepLoaiKhenThuong == null ||
             this.XepLoaiKhenThuong == model.XepLoaiKhenThuong) &&
            (this.MaHocKyNamHoc     == null ||
             this.MaHocKyNamHoc     == model.MaHocKyNamHoc)     &&
            (this.MaSinhVien        == null ||
             this.MaSinhVien        == model.MaSinhVien);
        }

        
    }

    public record class JustForInsertReqBody_KhenThuong : ReqBody_KhenThuong
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaKhenThuong { get; set; }
    }

}
