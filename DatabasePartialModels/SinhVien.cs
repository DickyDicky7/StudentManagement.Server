namespace StudentManagement.Server.Database
{
    public partial class SinhVien : IModel<SinhVien>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> LoaiTinhTrangHocTap { get; } = new()
        {
            "đang học",
            "thôi học", "tốt nghiệp", "bảo lưu kết quả", "đình chỉ học",
        };
    }
}
