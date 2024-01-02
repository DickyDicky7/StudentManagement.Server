namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_KetQuaRenLuyen : BaseReqBody<KetQuaRenLuyen>
    {
        public long  ? MaKetQuaRenLuyen { get; set; }
        public short ?  SoDiemRenLuyen  { get; set; }
        public string? XepLoaiRenLuyen  { get; set; }
        public long  ? MaHocKyNamHoc    { get; set; }
        public long  ? MaSinhVien       { get; set; }

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
        public new long? MaKetQuaRenLuyen { get; set; }
    }
}
