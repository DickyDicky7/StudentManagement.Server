namespace StudentManagement.Server.Bodies.Req.Specific
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
            return (model) =>
            (MaBuoiThi  == null ||
             MaBuoiThi  == model.MaBuoiThi)  &&
            (MaHocPhan  == null ||
             MaHocPhan  == model.MaHocPhan)  &&
            (NgayThi    == null ||
             NgayThi    == model.NgayThi)    &&
            (MaPhongThi == null ||
             MaPhongThi == model.MaPhongThi) &&
            (ThuThi     == null ||
             ThuThi     == model.ThuThi)     &&
            (CaThi      == null ||
             CaThi      == model.CaThi)      &&
            (GhiChu     == null ||
             GhiChu     == model.GhiChu);
        }
    }

    public record class JustForInsertReqBody_BuoiThi : ReqBody_BuoiThi
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBuoiThi { get; set; }
    }
}
