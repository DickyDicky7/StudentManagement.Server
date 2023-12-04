using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("giang_vien_thuoc_khoa_dao_tao")]
public partial class GiangVienThuocKhoaDaoTao
{
    [Key]
    [Column("ma_giang_vien")]
    public long MaGiangVien { get; set; }

    [Column("ma_khoa_dao_tao")]
    public long MaKhoaDaoTao { get; set; }

    [ForeignKey("MaGiangVien")]
    [InverseProperty("GiangVienThuocKhoaDaoTao")]
    public virtual GiangVien GiangVien { get; set; } = null!;

    [ForeignKey("MaKhoaDaoTao")]
    [InverseProperty("GiangVienThuocKhoaDaoTaos")]
    public virtual KhoaDaoTao KhoaDaoTao { get; set; } = null!;
}
