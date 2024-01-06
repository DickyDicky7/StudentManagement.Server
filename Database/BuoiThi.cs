using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("buoi_thi")]
public partial class BuoiThi
{
    [Key]
    [Column("ma_buoi_thi")]
    public long     MaBuoiThi  { get; set; }

    [Column("ma_hoc_phan")]
    public long     MaHocPhan  { get; set; }

    [Column("ngay_thi")]
    public DateTime NgayThi    { get; set; }

    [Column("ma_phong_thi")]
    public string   MaPhongThi { get; set; } = null!;

    [Column("thu_thi")]
    public string   ThuThi     { get; set; } = null!;

    [Column("ca_thi")]
    public string   CaThi      { get; set; } = null!;

    [Column("ghi_chu")]
    public string   GhiChu     { get; set; } = null!;

    [ForeignKey("MaHocPhan")]
    [InverseProperty("BuoiThis")]
    public virtual HocPhan HocPhan { get; set; } = null!;
}
