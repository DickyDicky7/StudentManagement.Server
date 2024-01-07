using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("buoi_hoc")]
public partial class BuoiHoc
{
    [Key]
    [Column("ma_buoi_hoc")]
    public long   MaBuoiHoc         { get; set; }

    [Column("ma_hoc_phan")]
    public long   MaHocPhan         { get; set; }

    [Column("thu_hoc")]
    public string ThuHoc            { get; set; } = null!;

    [Column("ca_hoc")]
    public string CaHoc             { get; set; } = null!;

    [Column("so_tiet_hoc")]
    public string SoTietHoc         { get; set; } = null!;

    [Column("so_tuan_hoc_cach_nhau")]
    public string SoTuanHocCachNhau { get; set; } = null!;

    [Column("ma_phong_hoc")]
    public string MaPhongHoc        { get; set; } = null!;

    [ForeignKey("MaHocPhan")]
    [InverseProperty("BuoiHocs")]
    public virtual HocPhan HocPhan { get; set; } = null!;
}
