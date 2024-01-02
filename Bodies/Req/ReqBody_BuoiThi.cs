namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_BuoiThi : BaseReqBody<BuoiThi>
    {
        public long    ? MaBuoiThi  { get; set; }
        public long    ? MaHocPhan  { get; set; }
        public DateOnly? NgayThi    { get; set; }
        public string  ? MaPhongThi { get; set; }
        public string  ? ThuThi     { get; set; }
        public string  ? CaThi      { get; set; }
        public string  ? GhiChu     { get; set; }

        public override Expression<Func<BuoiThi, bool>> MatchExpression()
        {
            return (BuoiThi model) =>
            (this.MaBuoiThi  == null ||
             this.MaBuoiThi  == model.MaBuoiThi)  &&
            (this.MaHocPhan  == null ||
             this.MaHocPhan  == model.MaHocPhan)  &&
            (this.NgayThi    == null ||
             this.NgayThi    == model.NgayThi)    &&
            (this.MaPhongThi == null ||
             this.MaPhongThi == model.MaPhongThi) &&
            (this.ThuThi     == null ||
             this.ThuThi     == model.ThuThi)     &&
            (this.CaThi      == null ||
             this.CaThi      == model.CaThi)      &&
            (this.GhiChu     == null ||
             this.GhiChu     == model.GhiChu);
        }

        
    }

    public record class JustForInsertReqBody_BuoiThi : ReqBody_BuoiThi
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBuoiThi { get; set; }
    }

}
