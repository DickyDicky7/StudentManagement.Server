namespace StudentManagement.Server.Database
{
    public partial class KhenThuong : IModel<KhenThuong>
    {
        public void  QuyetDinhXepLoaiKhenThuong(KetQuaHocTap ketQuaHocTap, KetQuaRenLuyen ketQuaRenLuyen)
        {
            if (ketQuaHocTap.XepLoaiHocTap is "giỏi"    )
            {
                this.XepLoaiKhenThuong =      "giỏi"    ;
            }
            else
            if (ketQuaHocTap.XepLoaiHocTap is "xuất sắc")
            {
                this.XepLoaiKhenThuong =      "xuất sắc";
            }
        }

        public bool KiemTraDuDieuKienKhenThuong(KetQuaHocTap ketQuaHocTap, KetQuaRenLuyen ketQuaRenLuyen)
        {
            return ketQuaHocTap  .XepLoaiHocTap   is          "giỏi" or "xuất sắc"
                && ketQuaRenLuyen.XepLoaiRenLuyen is "khá" or
                                                     "tốt" or           "xuất sắc";
        }
    }
}
