namespace StudentManagement.Server.Database
{
    public partial class KetQuaRenLuyen : IModel<KetQuaRenLuyen>
    {
        public Common.BacDiem? TinhBacDiemRenLuyen()
        {
            return KetQuaRenLuyen
            .ThangDiemDanhGiaKetQuaRenLuyen.FirstOrDefault(bacDiem =>
              (bacDiem.LonHonHoacBang != null && this.SoDiemRenLuyen >= bacDiem.LonHonHoacBang) &&
            ( (bacDiem.NhoHon         != null && this.SoDiemRenLuyen <  bacDiem.NhoHon        ) ||
              (bacDiem.NhoHonHoacBang != null && this.SoDiemRenLuyen <= bacDiem.NhoHonHoacBang)));
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public static List<Common.BacDiem> ThangDiemDanhGiaKetQuaRenLuyen { get; } = new()
        {
            new()
            {
                Dat            = true         ,
                XepLoai        = "xuất sắc"   ,
                NhoHonHoacBang = 100m         ,
                LonHonHoacBang = 090m         ,
            }                                 ,
            new()
            {
                Dat            = true         ,
                XepLoai        = "tốt"        ,
                NhoHon         = 090m         ,
                LonHonHoacBang = 080m         ,
            }                                 ,
            new()
            {
                Dat            = true         ,
                XepLoai        = "khá"        ,
                NhoHon         = 080m         ,
                LonHonHoacBang = 065m         ,
            }                                 ,
            new()
            {
                Dat            = true         ,
                XepLoai        = "trung bình" ,
                NhoHon         = 065m         ,
                LonHonHoacBang = 050m         ,
            }                                 ,
            new()
            {
                Dat            = false        ,
                XepLoai        = "yếu"        ,
                NhoHon         = 050m         ,
                LonHonHoacBang = 000m         ,
            }                                 ,
        };
    }
}
