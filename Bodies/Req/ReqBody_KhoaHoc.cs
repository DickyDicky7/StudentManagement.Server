namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhoaHoc : BaseReqBody<ReqBody_KhoaHoc, KhoaHoc>
    {
        public long  ?  MaKhoaHoc          { get; set; }
        public string? TenKhoaHoc          { get; set; }
        public long  ? MaCoVanHocTap       { get; set; }
        public string? TenLopSinhHoatChung { get; set; }

        public override Func<ReqBody_KhoaHoc, Expression<Func<KhoaHoc, bool>>> MatchExpression { get; set; } =
        (ReqBody_KhoaHoc reqBody) => (KhoaHoc model) =>
        (reqBody. MaKhoaHoc          == null ||
         reqBody. MaKhoaHoc          == model. MaKhoaHoc)    &&
        (reqBody.TenKhoaHoc          == null ||
         reqBody.TenKhoaHoc          == model.TenKhoaHoc)    &&
        (reqBody.MaCoVanHocTap       == null ||
         reqBody.MaCoVanHocTap       == model.MaCoVanHocTap) &&
        (reqBody.TenLopSinhHoatChung == null ||
         reqBody.TenLopSinhHoatChung == model.TenLopSinhHoatChung);
    }
}
