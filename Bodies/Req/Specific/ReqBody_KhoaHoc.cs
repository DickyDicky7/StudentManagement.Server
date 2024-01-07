namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KhoaHoc : BaseReqBody<KhoaHoc>
    {
        public long  ?  MaKhoaHoc          { get; set; }
        public string? TenKhoaHoc          { get; set; }
        public long  ? MaCoVanHocTap       { get; set; }
        public string? TenLopSinhHoatChung { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaHoc>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaHoc>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaHoc>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KhoaHoc>>> chain = setter => setter;

            if (this.MaKhoaHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhoaHoc,
                        this  .MaKhoaHoc));

            if (this.TenKhoaHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenKhoaHoc,
                        this  .TenKhoaHoc));

            if (this.MaCoVanHocTap != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaCoVanHocTap,
                        this  .MaCoVanHocTap));

            if (this.TenLopSinhHoatChung != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenLopSinhHoatChung,
                        this  .TenLopSinhHoatChung));

            return chain;
        }

        public override Expression<Func<KhoaHoc, bool>> MatchExpression()
        {
            return (model) =>
            ( MaKhoaHoc          == null ||
              MaKhoaHoc          == model. MaKhoaHoc)    &&
            (TenKhoaHoc          == null ||
             TenKhoaHoc          == model.TenKhoaHoc)    &&
            (MaCoVanHocTap       == null ||
             MaCoVanHocTap       == model.MaCoVanHocTap) &&
            (TenLopSinhHoatChung == null ||
             TenLopSinhHoatChung == model.TenLopSinhHoatChung);
        }
    }

    public record class JustForInsertReqBody_KhoaHoc : ReqBody_KhoaHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaKhoaHoc { get; set; }
    }
}
