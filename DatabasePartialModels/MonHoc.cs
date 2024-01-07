namespace StudentManagement.Server.Database
{
    public partial class MonHoc : IModel<MonHoc>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> DanhSachCongThucTinhTongDiemMonHoc { get; } = new()
        {
            "0.5 * tổng điểm thực hành lý thuyết + 0.5 * tổng điểm học phần thực hành",
            "1.0 * tổng điểm thực hành lý thuyết",
        };
    }
}
