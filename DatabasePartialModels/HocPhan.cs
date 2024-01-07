namespace StudentManagement.Server.Database
{
    public partial class HocPhan : IModel<HocPhan>
    {
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> DanhSachLoaiHinhThucThi { get; } = new()
        {
            "bài kiểm tra lý thuyết cuối kỳ",
            "bài kiểm tra thực hành cuối kỳ",
        };

        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> DanhSachLoaiHocPhan     { get; } = new()
        {
            "tự chọn", "bắt buộc",
        };
    }
}
