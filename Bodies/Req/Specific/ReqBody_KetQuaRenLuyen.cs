namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KetQuaRenLuyen : BaseReqBody<KetQuaRenLuyen>
    {
        public long  ? MaKetQuaRenLuyen { get; set; }
        public short ?  SoDiemRenLuyen  { get; set; }
        public string? XepLoaiRenLuyen  { get; set; }
        public long  ? MaHocKyNamHoc    { get; set; }
        public long  ? MaSinhVien       { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaRenLuyen>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaRenLuyen>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaRenLuyen>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<KetQuaRenLuyen>>> chain = setter => setter;

            if (this.MaKetQuaRenLuyen != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaKetQuaRenLuyen,
                        this  .MaKetQuaRenLuyen));

            if (this.SoDiemRenLuyen != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoDiemRenLuyen,
                        this  .SoDiemRenLuyen));

            if (this.XepLoaiRenLuyen != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.XepLoaiRenLuyen,
                        this  .XepLoaiRenLuyen));

            if (this.MaHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocKyNamHoc,
                        this  .MaHocKyNamHoc));

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            return chain;
        }

        public override Expression<Func<KetQuaRenLuyen, bool>> MatchExpression()
        {
            return (model) =>
            (MaKetQuaRenLuyen == null ||
             MaKetQuaRenLuyen == model.MaKetQuaRenLuyen) &&
            ( SoDiemRenLuyen  == null ||
              SoDiemRenLuyen  == model. SoDiemRenLuyen)  &&
            (XepLoaiRenLuyen  == null ||
             XepLoaiRenLuyen  == model.XepLoaiRenLuyen)  &&
            (MaHocKyNamHoc    == null ||
             MaHocKyNamHoc    == model.MaHocKyNamHoc)    &&
            (MaSinhVien       == null ||
             MaSinhVien       == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_KetQuaRenLuyen : ReqBody_KetQuaRenLuyen
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long  ? MaKetQuaRenLuyen { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public new string?  XepLoaiRenLuyen { get; set; }
    }
}
