namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocKhoaDaoTao : BaseReqBody<GiangVienThuocKhoaDaoTao>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaKhoaDaoTao { get; set; }

        public override Expression<Func<GiangVienThuocKhoaDaoTao, bool>> MatchExpression()
        {
            return (GiangVienThuocKhoaDaoTao model) =>
            (this. MaGiangVien == null ||
             this. MaGiangVien == model. MaGiangVien) &&
            (this.TenGiangVien == null ||
             this.TenGiangVien == model.TenGiangVien) &&
            (this.MaKhoaDaoTao == null ||
             this.MaKhoaDaoTao == model.MaKhoaDaoTao);
        }
    }
}
