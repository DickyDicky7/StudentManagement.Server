namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KetQuaHocTap : BaseReqBody<KetQuaHocTap>
    {
        public long   ? MaKetQuaHocTap     { get; set; }
        public decimal? DiemTrungBinhHocKy { get; set; }
        public string ? XepLoaiHocTap      { get; set; }
        public long   ? MaHocKyNamHoc      { get; set; }
        public long   ? MaSinhVien         { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaHocTap>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaHocTap>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaHocTap>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaHocTap>>> chain = setter => setter;

            if (this.MaKetQuaHocTap != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKetQuaHocTap,
                        this  .MaKetQuaHocTap));

            if (this.DiemTrungBinhHocKy != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DiemTrungBinhHocKy,
                        this  .DiemTrungBinhHocKy));

            if (this.XepLoaiHocTap != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.XepLoaiHocTap,
                        this  .XepLoaiHocTap));

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
        public new long   ? MaKetQuaHocTap     { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public new decimal? DiemTrungBinhHocKy { get; set; }
        
        [SwaggerSchema(ReadOnly = true)]
        public new string ?  XepLoaiHocTap     { get; set; }
    }
}
