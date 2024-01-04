namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KhenThuong : BaseReqBody<KhenThuong>
    {
        public long  ? MaKhenThuong      { get; set; }
        public string? XepLoaiKhenThuong { get; set; }
        public long  ? MaHocKyNamHoc     { get; set; }
        public long  ? MaSinhVien        { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhenThuong>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhenThuong>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhenThuong>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhenThuong>>> chain = setter => setter;

            if (this.MaKhenThuong != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhenThuong,
                        this  .MaKhenThuong));

            if (this.XepLoaiKhenThuong != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.XepLoaiKhenThuong,
                        this  .XepLoaiKhenThuong));

            if (this.MaHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocKyNamHoc,
                        this  .MaHocKyNamHoc));

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            return chain;
        }

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
