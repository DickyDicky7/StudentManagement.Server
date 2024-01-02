namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_GiangVienThuocBoMon : BaseReqBody<GiangVienThuocBoMon>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaBoMon      { get; set; }

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
