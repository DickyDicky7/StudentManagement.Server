namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_ChuyenNganh : BaseReqBody<ChuyenNganh>
    {
        public long  ?  MaChuyenNganh { get; set; }
        public string? TenChuyenNganh { get; set; }
        public long  ? MaKhoaDaoTao   { get; set; }

        public override bool Match(ChuyenNganh model)
        {
            return       (this. MaChuyenNganh == null ||
            Object.Equals(this. MaChuyenNganh, model. MaChuyenNganh)) &&
                         (this.TenChuyenNganh == null ||
            Object.Equals(this.TenChuyenNganh, model.TenChuyenNganh)) &&
                         (this.MaKhoaDaoTao   == null ||
            Object.Equals(this.MaKhoaDaoTao  , model.MaKhoaDaoTao));
        }
    }
}
