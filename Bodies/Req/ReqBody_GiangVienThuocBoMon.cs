namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocBoMon : BaseReqBody<ReqBody_GiangVienThuocBoMon, GiangVienThuocBoMon>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaBoMon      { get; set; }

        public override Func<ReqBody_GiangVienThuocBoMon, Expression<Func<GiangVienThuocBoMon, bool>>> MatchExpression { get; set; } =
        (ReqBody_GiangVienThuocBoMon reqBody) => (GiangVienThuocBoMon model) =>
        (reqBody. MaGiangVien == null ||
         reqBody. MaGiangVien == model. MaGiangVien) &&
        (reqBody.TenGiangVien == null ||
         reqBody.TenGiangVien == model.TenGiangVien) &&
        (reqBody.MaBoMon      == null ||
         reqBody.MaBoMon      == model.MaBoMon);
    }
}
