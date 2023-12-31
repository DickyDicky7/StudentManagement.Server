namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaRenLuyen : BaseReqBody<KetQuaRenLuyen>
    {
        public long  ? MaKetQuaRenLuyen { get; set; }
        public short ?  SoDiemRenLuyen  { get; set; }
        public string? XepLoaiRenLuyen  { get; set; }
        public long  ? MaHocKyNamHoc    { get; set; }
        public long  ? MaSinhVien       { get; set; }

        public override bool Match(KetQuaRenLuyen model)
        {
            return (      this.MaKetQuaRenLuyen == null ||
            Object.Equals(this.MaKetQuaRenLuyen, model.MaKetQuaRenLuyen)) &&
            (             this. SoDiemRenLuyen  == null ||
            Object.Equals(this. SoDiemRenLuyen , model. SoDiemRenLuyen))  &&
            (             this.XepLoaiRenLuyen  == null ||
            Object.Equals(this.XepLoaiRenLuyen , model.XepLoaiRenLuyen))  &&
            (             this.MaHocKyNamHoc    == null ||
            Object.Equals(this.MaHocKyNamHoc   , model.MaHocKyNamHoc))    &&
            (             this.MaSinhVien       == null ||
            Object.Equals(this.MaSinhVien      , model.MaSinhVien));
        }
    }
}
