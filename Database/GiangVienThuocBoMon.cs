using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("giang_vien_thuoc_bo_mon")]
public partial class GiangVienThuocBoMon
{
    [Key]
    [Column("ma_giang_vien")]
    public long MaGiangVien { get; set; }

    [Column("ma_bo_mon")]
    public long MaBoMon { get; set; }

    [ForeignKey("MaBoMon")]
    [InverseProperty("GiangVienThuocBoMons")]
    public virtual BoMon BoMon { get; set; } = null!;

    [ForeignKey("MaGiangVien")]
    [InverseProperty("GiangVienThuocBoMon")]
    public virtual GiangVien GiangVien { get; set; } = null!;
}
