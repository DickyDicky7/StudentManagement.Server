namespace StudentManagement.Server.Database
{
    public partial class SinhVien : IModel<SinhVien>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<string> LoaiTinhTrangHocTaps { get; } = new()
        {
            "đang học",
            "thôi học", "tốt nghiệp", "bảo lưu kết quả", "đình chỉ học",
        };
    }
}
