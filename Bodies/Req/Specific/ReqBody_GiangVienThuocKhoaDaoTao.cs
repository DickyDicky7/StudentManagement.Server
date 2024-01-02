namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_GiangVienThuocKhoaDaoTao : BaseReqBody<GiangVienThuocKhoaDaoTao>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaKhoaDaoTao { get; set; }

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
