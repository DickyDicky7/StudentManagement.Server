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
    }

    public record class JustForInsertReqBody_GiangVien : ReqBody_GiangVien
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaGiangVien { get; set; }
    }
}
