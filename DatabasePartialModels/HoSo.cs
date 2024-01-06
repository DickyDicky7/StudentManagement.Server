namespace StudentManagement.Server.Database
{
    public partial class HoSo : IModel<HoSo>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> DanhSachLoaiHoSo { get; } = new()
        {
            "nhập học",
            "thôi học",
            "xin nhập học lại", "bảo lưu", "tốt nghiệp",
        };
    }
}
