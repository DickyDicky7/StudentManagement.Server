namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_BuoiHoc : BaseReqBody<BuoiHoc>
    {
        public long  ? MaBuoiHoc         { get; set; }
        public long  ? MaHocPhan         { get; set; }
        public string? ThuHoc            { get; set; }
        public string? CaHoc             { get; set; }
        public string? SoTietHoc         { get; set; }
        public string? SoTuanHocCachNhau { get; set; }
        public string? MaPhongHoc        { get; set; }

        public override Expression<Func<BuoiHoc, bool>> MatchExpression()
        {
            return (model) =>
            (MaBuoiHoc         == null ||
             MaBuoiHoc         == model.MaBuoiHoc)         &&
            (MaHocPhan         == null ||
             MaHocPhan         == model.MaHocPhan)         &&
            (ThuHoc            == null ||
             ThuHoc            == model.ThuHoc)            &&
            (CaHoc             == null ||
             CaHoc             == model.CaHoc)             &&
            (SoTietHoc         == null ||
             SoTietHoc         == model.SoTietHoc)         &&
            (SoTuanHocCachNhau == null ||
             SoTuanHocCachNhau == model.SoTuanHocCachNhau) &&
            (MaPhongHoc        == null ||
             MaPhongHoc        == model.MaPhongHoc);
        }
    }

    public record class JustForInsertReqBody_BuoiHoc : ReqBody_BuoiHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBuoiHoc { get; set; }
    }
}
