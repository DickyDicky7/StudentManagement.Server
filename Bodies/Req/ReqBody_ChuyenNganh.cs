namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ChuyenNganh : BaseReqBody<ChuyenNganh>
    {
        public long  ?  MaChuyenNganh { get; set; }
        public string? TenChuyenNganh { get; set; }
        public long  ? MaKhoaDaoTao   { get; set; }
    }
}
