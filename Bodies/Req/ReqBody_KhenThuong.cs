namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_KhenThuong : BaseReqBody<KhenThuong>
    {
        public long  ? MaKhenThuong      { get; set; }
        public string? XepLoaiKhenThuong { get; set; }
        public long  ? MaHocKyNamHoc     { get; set; }
        public long  ? MaSinhVien        { get; set; }

        public override bool Match(KhenThuong model)
        {
            return (      this.MaKhenThuong      == null ||
            Object.Equals(this.MaKhenThuong     , model.MaKhenThuong))      &&
            (             this.XepLoaiKhenThuong == null ||
            Object.Equals(this.XepLoaiKhenThuong, model.XepLoaiKhenThuong)) &&
            (             this.MaHocKyNamHoc     == null ||
            Object.Equals(this.MaHocKyNamHoc    , model.MaHocKyNamHoc))     &&
            (             this.MaSinhVien        == null ||
            Object.Equals(this.MaSinhVien       , model.MaSinhVien));
        }
    }
}
