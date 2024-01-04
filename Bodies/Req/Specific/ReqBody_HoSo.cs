namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_HoSo : BaseReqBody<HoSo>
    {
        public long    ? MaHoSo          { get; set; }
        public bool    ? HoanThanh       { get; set; }
        public string  ? GhiChu          { get; set; }
        public string  ? LoaiHoSo        { get; set; }
        public string[]? DanhSachDinhKem { get; set; }
        public long    ? MaSinhVien      { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HoSo>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HoSo>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HoSo>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<HoSo>>> chain = setter => setter;

            if (this.MaHoSo != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHoSo,
                        this  .MaHoSo));

            if (this.HoanThanh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.HoanThanh,
                        this  .HoanThanh));

            if (this.GhiChu != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.GhiChu,
                        this  .GhiChu));

            if (this.LoaiHoSo != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.LoaiHoSo,
                        this  .LoaiHoSo));

            if (this.DanhSachDinhKem != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DanhSachDinhKem,
                        this  .DanhSachDinhKem));

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            return chain;
        }

        public override Expression<Func<HoSo, bool>> MatchExpression()
        {
            return (model) =>
            (MaHoSo          == null ||
             MaHoSo          == model.MaHoSo)          &&
            (HoanThanh       == null ||
             HoanThanh       == model.HoanThanh)       &&
            (GhiChu          == null ||
             GhiChu          == model.GhiChu)          &&
            (LoaiHoSo        == null ||
             LoaiHoSo        == model.LoaiHoSo)        &&
            (DanhSachDinhKem == null ||
             DanhSachDinhKem == model.DanhSachDinhKem) &&
            (MaSinhVien      == null ||
             MaSinhVien      == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_HoSo : ReqBody_HoSo
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaHoSo { get; set; }
    }
}
