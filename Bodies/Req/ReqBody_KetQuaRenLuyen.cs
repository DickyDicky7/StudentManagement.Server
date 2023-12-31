namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KetQuaRenLuyen : BaseReqBody<KetQuaRenLuyen>
    {
        public long  ? MaKetQuaRenLuyen { get; set; }
        public short ?  SoDiemRenLuyen  { get; set; }
        public string? XepLoaiRenLuyen  { get; set; }
        public long  ? MaHocKyNamHoc    { get; set; }
        public long  ? MaSinhVien       { get; set; }
    }
}
