namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_GiangVienThuocBoMon : BaseReqBody<GiangVienThuocBoMon>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaBoMon      { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocBoMon>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocBoMon>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocBoMon>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocBoMon>>> chain = setter => setter;

            if (this.MaGiangVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaGiangVien,
                        this  .MaGiangVien));

            if (this.TenGiangVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenGiangVien,
                        this  .TenGiangVien));

            if (this.MaBoMon != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaBoMon,
                        this  .MaBoMon));

            return chain;
        }

        public override Expression<Func<GiangVienThuocBoMon, bool>> MatchExpression()
        {
            return (model) =>
            ( MaGiangVien == null ||
              MaGiangVien == model. MaGiangVien) &&
            (TenGiangVien == null ||
             TenGiangVien == model.TenGiangVien) &&
            (MaBoMon      == null ||
             MaBoMon      == model.MaBoMon);
        }
    }

    public record class JustForInsertReqBody_GiangVienThuocBoMon : ReqBody_GiangVienThuocBoMon
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaGiangVien { get; set; }
    }
}
