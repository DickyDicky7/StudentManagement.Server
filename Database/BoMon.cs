using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("bo_mon")]
public partial class BoMon
{
    [Key]
    [Column("ma_bo_mon")]
    public long MaBoMon { get; set; }

    [Column("ten_bo_mon")]
    public string TenBoMon { get; set; } = null!;

    [InverseProperty("MaBoMonNavigation")]
    public virtual ICollection<GiangVienThuocBoMon> GiangVienThuocBoMons { get; set; } = new List<GiangVienThuocBoMon>();

    [InverseProperty("MaBoMonNavigation")]
    public virtual ICollection<MonHocThuocBoMon> MonHocThuocBoMons { get; set; } = new List<MonHocThuocBoMon>();
}
