namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocKhoaDaoTao : BaseReqBody<GiangVienThuocKhoaDaoTao>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaKhoaDaoTao { get; set; }

        public override bool Match(GiangVienThuocKhoaDaoTao model)
        {
            return (      this. MaGiangVien == null ||
            Object.Equals(this. MaGiangVien, model. MaGiangVien)) &&
            (             this.TenGiangVien == null ||
            Object.Equals(this.TenGiangVien, model.TenGiangVien)) &&
            (             this.MaKhoaDaoTao == null ||
            Object.Equals(this.MaKhoaDaoTao, model.MaKhoaDaoTao));
        }
    }
}
