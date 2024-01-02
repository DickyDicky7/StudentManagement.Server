namespace StudentManagement.Server.Bodies.Req
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
            return (BuoiHoc model) =>
            (this.MaBuoiHoc         == null ||
             this.MaBuoiHoc         == model.MaBuoiHoc)         &&
            (this.MaHocPhan         == null ||
             this.MaHocPhan         == model.MaHocPhan)         &&
            (this.ThuHoc            == null ||
             this.ThuHoc            == model.ThuHoc)            &&
            (this.CaHoc             == null ||
             this.CaHoc             == model.CaHoc)             &&
            (this.SoTietHoc         == null ||
             this.SoTietHoc         == model.SoTietHoc)         &&
            (this.SoTuanHocCachNhau == null ||
             this.SoTuanHocCachNhau == model.SoTuanHocCachNhau) &&
            (this.MaPhongHoc        == null ||
             this.MaPhongHoc        == model.MaPhongHoc);
        }

        
    }

    public record class JustForInsertReqBody_BuoiHoc : ReqBody_BuoiHoc
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaBuoiHoc { get; set; }
    }

}
