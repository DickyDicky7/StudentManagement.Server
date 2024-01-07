namespace StudentManagement.Server.Database
{
    public partial class SinhVien : IModel<SinhVien>
    {
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> DanhSachLoaiTinhTrangHocTap { get; } = new()
        {
            "đang học",
            "thôi học", "tốt nghiệp", "bảo lưu kết quả", "đình chỉ học",
        };

        public void CapNhatTinhTrangHocTapSauKhiNopHoSo()
        {

            if (this.HoSos != null)
            {
                HoSo hoSoMoiNhat = this.HoSos.OrderBy(hoSo => hoSo.MaHoSo).LastOrDefault()!;
                if ( hoSoMoiNhat == null)
                    return;
                if (!hoSoMoiNhat.HoanThanh)
                    return;
                if ( hoSoMoiNhat.LoaiHoSo == "nhập học")
                    this.TinhTrangHocTap =   "đang học";
                else
                if ( hoSoMoiNhat.LoaiHoSo == "thôi học")
                    this.TinhTrangHocTap =   "thôi học";
                else
                if ( hoSoMoiNhat.LoaiHoSo == "xin nhập học lại")
                    this.TinhTrangHocTap =   "đang học";
                else
                if ( hoSoMoiNhat.LoaiHoSo == "bảo lưu")
                    this.TinhTrangHocTap =   "bảo lưu kết quả";
                else
                if ( hoSoMoiNhat.LoaiHoSo == "tốt nghiệp")
                    this.TinhTrangHocTap =   "tốt nghiệp";
            }
        }
    }
}
