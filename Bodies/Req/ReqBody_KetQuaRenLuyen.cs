namespace StudentManagement.Server.Bodies.Req
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
            return (KetQuaRenLuyen model) =>
            (this.MaKetQuaRenLuyen == null ||
             this.MaKetQuaRenLuyen == model.MaKetQuaRenLuyen) &&
            (this. SoDiemRenLuyen  == null ||
             this. SoDiemRenLuyen  == model. SoDiemRenLuyen)  &&
            (this.XepLoaiRenLuyen  == null ||
             this.XepLoaiRenLuyen  == model.XepLoaiRenLuyen)  &&
            (this.MaHocKyNamHoc    == null ||
             this.MaHocKyNamHoc    == model.MaHocKyNamHoc)    &&
            (this.MaSinhVien       == null ||
             this.MaSinhVien       == model.MaSinhVien);
        }

        
    }

    public record class JustForInsertReqBody_KetQuaRenLuyen : ReqBody_KetQuaRenLuyen
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaKetQuaRenLuyen { get; set; }
    }

}
