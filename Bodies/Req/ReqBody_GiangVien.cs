namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVien : BaseReqBody<GiangVien>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }

        public override Expression<Func<GiangVien, bool>> MatchExpression()
        {
            return (GiangVien model) =>
            (this. MaGiangVien == null ||
             this. MaGiangVien == model. MaGiangVien) &&
            (this.TenGiangVien == null ||
             this.TenGiangVien == model.TenGiangVien);
        }

        
    }

    public record class JustForInsertReqBody_GiangVien : ReqBody_GiangVien
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaGiangVien { get; set; }
    }

}
