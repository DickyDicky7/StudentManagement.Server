namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocKhoaDaoTao : BaseReqBody<ReqBody_GiangVienThuocKhoaDaoTao, GiangVienThuocKhoaDaoTao>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaKhoaDaoTao { get; set; }

        public override Func<ReqBody_GiangVienThuocKhoaDaoTao, Expression<Func<GiangVienThuocKhoaDaoTao, bool>>> MatchExpression { get; set; } =
        (ReqBody_GiangVienThuocKhoaDaoTao reqBody) => (GiangVienThuocKhoaDaoTao model) =>
        (reqBody. MaGiangVien == null ||
         reqBody. MaGiangVien == model. MaGiangVien) &&
        (reqBody.TenGiangVien == null ||
         reqBody.TenGiangVien == model.TenGiangVien) &&
        (reqBody.MaKhoaDaoTao == null ||
         reqBody.MaKhoaDaoTao == model.MaKhoaDaoTao);
    }
}
