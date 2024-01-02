namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KhoaHoc : BaseReqBody<KhoaHoc>
    {
        public long  ?  MaKhoaHoc          { get; set; }
        public string? TenKhoaHoc          { get; set; }
        public long  ? MaCoVanHocTap       { get; set; }
        public string? TenLopSinhHoatChung { get; set; }

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
