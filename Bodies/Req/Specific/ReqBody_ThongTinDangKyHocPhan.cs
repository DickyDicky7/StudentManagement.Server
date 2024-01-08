namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ThongTinDangKyHocPhan : BaseReqBody<ThongTinDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocKyNamHoc           { get; set; }
        public long? MaSinhVien              { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinDangKyHocPhan>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinDangKyHocPhan>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinDangKyHocPhan>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinDangKyHocPhan>>> chain = setter => setter;

            if (this.MaThongTinDangKyHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinDangKyHocPhan,
                        this  .MaThongTinDangKyHocPhan));

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

        public override Expression<Func<ThongTinDangKyHocPhan, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinDangKyHocPhan == null ||
             MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan) &&
            (MaHocKyNamHoc           == null ||
             MaHocKyNamHoc           == model.MaHocKyNamHoc)           &&
            (MaSinhVien              == null ||
             MaSinhVien              == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_ThongTinDangKyHocPhan : ReqBody_ThongTinDangKyHocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaThongTinDangKyHocPhan { get; set; }
    }
}
