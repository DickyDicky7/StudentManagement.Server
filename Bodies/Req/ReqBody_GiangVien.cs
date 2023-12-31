namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVien : BaseReqBody<GiangVien>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }

        public override bool Match(GiangVien model)
        {
            return (      this. MaGiangVien == null ||
            Object.Equals(this. MaGiangVien, model. MaGiangVien)) &&
            (             this.TenGiangVien == null ||
            Object.Equals(this.TenGiangVien, model.TenGiangVien));
        }
    }
}
