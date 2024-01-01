namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocBoMon : BaseReqBody<GiangVienThuocBoMon>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaBoMon      { get; set; }

        public override Expression<Func<GiangVienThuocBoMon, bool>> MatchExpression()
        {
            return (GiangVienThuocBoMon model) =>
            (this. MaGiangVien == null ||
             this. MaGiangVien == model. MaGiangVien) &&
            (this.TenGiangVien == null ||
             this.TenGiangVien == model.TenGiangVien) &&
            (this.MaBoMon      == null ||
             this.MaBoMon      == model.MaBoMon);
        }
    }
}
