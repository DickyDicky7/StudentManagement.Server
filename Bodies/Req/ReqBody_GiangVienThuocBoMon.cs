namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVienThuocBoMon : BaseReqBody<GiangVienThuocBoMon>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }
        public long  ? MaBoMon      { get; set; }

        public override bool Match(GiangVienThuocBoMon model)
        {
            return (      this. MaGiangVien == null ||
            Object.Equals(this. MaGiangVien, model. MaGiangVien)) &&
            (             this.TenGiangVien == null ||
            Object.Equals(this.TenGiangVien, model.TenGiangVien)) &&
            (             this.MaBoMon      == null ||
            Object.Equals(this.MaBoMon     , model.MaBoMon));
        }
    }
}
