namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_GiangVien : BaseReqBody<ReqBody_GiangVien, GiangVien>
    {
        public long  ?  MaGiangVien { get; set; }
        public string? TenGiangVien { get; set; }

        public override Func<ReqBody_GiangVien, Expression<Func<GiangVien, bool>>> MatchExpression { get; set; } =
        (ReqBody_GiangVien reqBody) => (GiangVien model) =>
        (reqBody. MaGiangVien == null ||
         reqBody. MaGiangVien == model. MaGiangVien) &&
        (reqBody.TenGiangVien == null ||
         reqBody.TenGiangVien == model.TenGiangVien);
    }
}
