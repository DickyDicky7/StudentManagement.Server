namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaRenLuyen : BaseReqBody<ReqBody_KetQuaRenLuyen, KetQuaRenLuyen>
    {
        public long  ? MaKetQuaRenLuyen { get; set; }
        public short ?  SoDiemRenLuyen  { get; set; }
        public string? XepLoaiRenLuyen  { get; set; }
        public long  ? MaHocKyNamHoc    { get; set; }
        public long  ? MaSinhVien       { get; set; }

        public override Func<ReqBody_KetQuaRenLuyen, Expression<Func<KetQuaRenLuyen, bool>>> MatchExpression { get; set; } =
        (ReqBody_KetQuaRenLuyen reqBody) => (KetQuaRenLuyen model) =>
        (reqBody.MaKetQuaRenLuyen == null ||
         reqBody.MaKetQuaRenLuyen == model.MaKetQuaRenLuyen) &&
        (reqBody. SoDiemRenLuyen  == null ||
         reqBody. SoDiemRenLuyen  == model. SoDiemRenLuyen)  &&
        (reqBody.XepLoaiRenLuyen  == null ||
         reqBody.XepLoaiRenLuyen  == model.XepLoaiRenLuyen)  &&
        (reqBody.MaHocKyNamHoc    == null ||
         reqBody.MaHocKyNamHoc    == model.MaHocKyNamHoc)    &&
        (reqBody.MaSinhVien       == null ||
         reqBody.MaSinhVien       == model.MaSinhVien);
    }
}
