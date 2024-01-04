namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_GiangVienThuocKhoaDaoTao : BaseReqBody<GiangVienThuocKhoaDaoTao>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaKhoaDaoTao { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocKhoaDaoTao>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocKhoaDaoTao>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocKhoaDaoTao>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVienThuocKhoaDaoTao>>> chain = setter => setter;

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

            if (this.MaKhoaDaoTao != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKhoaDaoTao,
                        this  .MaKhoaDaoTao));

            return chain;
        }

        public override Expression<Func<GiangVienThuocKhoaDaoTao, bool>> MatchExpression()
        {
            return (model) =>
            ( MaGiangVien == null ||
              MaGiangVien == model. MaGiangVien) &&
            (TenGiangVien == null ||
             TenGiangVien == model.TenGiangVien) &&
            (MaKhoaDaoTao == null ||
             MaKhoaDaoTao == model.MaKhoaDaoTao);
        }
    }

    public record class JustForInsertReqBody_GiangVienThuocKhoaDaoTao : ReqBody_GiangVienThuocKhoaDaoTao
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaGiangVien { get; set; }
    }
}
