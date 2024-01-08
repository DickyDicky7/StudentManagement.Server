namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_GiangVien : BaseReqBody<GiangVien>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }

        public override Expression<Func<GiangVien, bool>> MatchExpression()
        {
            return (model) =>
            ( MaGiangVien == null ||
              MaGiangVien == model. MaGiangVien) &&
            (TenGiangVien == null ||
             TenGiangVien == model.TenGiangVien);
        }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVien>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVien>>> UpdateModelExpression()
        {
            Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVien>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<GiangVien>>> chain = setter => setter;

            if (this.MaGiangVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        giangVien =>
                        giangVien.MaGiangVien,
                        this     .MaGiangVien));

            if (this.TenGiangVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        giangVien =>
                        giangVien.TenGiangVien,
                        this     .TenGiangVien));

            return chain;
        }
    }

    public record class JustForInsertReqBody_GiangVien : ReqBody_GiangVien
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaGiangVien { get; set; }
    }
}
