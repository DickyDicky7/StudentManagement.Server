using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("giang_vien_thuoc_bo_mon")]
public partial class GiangVienThuocBoMon : GiangVien
{
    [Column("ma_bo_mon")]
    public long MaBoMon { get; set; }

    [ForeignKey("MaBoMon")]
    [InverseProperty("GiangVienThuocBoMons")]
    public virtual BoMon BoMon { get; set; } = null!;
}
