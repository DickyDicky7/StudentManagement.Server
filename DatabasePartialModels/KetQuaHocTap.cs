namespace StudentManagement.Server.Database
{
    public partial class KetQuaHocTap : IModel<KetQuaHocTap>
    {
        public Common.BacDiem? TinhBacDiemHocTap()
        {
            return KetQuaHocTap
            .ThangDiemHocTap.FirstOrDefault(bacDiem =>
              (bacDiem.LonHonHoacBang != null && this.DiemTrungBinhHocKy >= bacDiem.LonHonHoacBang) &&
            ( (bacDiem.NhoHon         != null && this.DiemTrungBinhHocKy <  bacDiem.NhoHon        ) ||
              (bacDiem.NhoHonHoacBang != null && this.DiemTrungBinhHocKy <= bacDiem.NhoHonHoacBang)));
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<Common.BacDiem> ThangDiemHocTap { get; } = new()
        {
            new()
            {
                Dat            = true            ,
                XepLoai        = "xuất sắc"      ,
                NhoHonHoacBang = 10.0m           ,
                LonHonHoacBang = 09.0m           ,
            }                                    ,
            new()
            {
                Dat            = true            ,
                XepLoai        = "giỏi"          ,
                NhoHon         = 09.0m           ,
                LonHonHoacBang = 08.0m           ,
            }                                    ,
            new()
            {
                Dat            = true            ,
                XepLoai        = "khá"           ,
                NhoHon         = 08.0m           ,
                LonHonHoacBang = 07.0m           ,
            }                                    ,
            new()
            {
                Dat            = true            ,
                XepLoai        = "trung bình khá",
                NhoHon         = 07.0m           ,
                LonHonHoacBang = 06.0m          ,
            }                                    ,
            new()
            {
                Dat            = true            ,
                XepLoai        = "trung bình"    ,
                NhoHon         = 06.0m           ,
                LonHonHoacBang = 05.0m           ,
            }                                    ,
            new()
            {
                Dat            = false           ,
                XepLoai        = "yếu"           ,
                NhoHon         = 05.0m           ,
                LonHonHoacBang = 04.0m           ,
            }                                    ,
            new()
            {
                Dat            = false           ,
                XepLoai        = "kém"           ,
                NhoHon         = 04.0m           ,
                LonHonHoacBang = 00.0m           ,
            }                                    ,
        };
    }
}
