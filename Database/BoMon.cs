using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("bo_mon")]
public partial class BoMon
{
    [Key]
    [Column("ma_bo_mon")]
    public long    MaBoMon { get; set; }

    [Column("ten_bo_mon")]
    public string TenBoMon { get; set; } = null!;

    [InverseProperty("BoMon")]
    public virtual ICollection<GiangVienThuocBoMon> GiangVienThuocBoMons { get; set; } = new List<GiangVienThuocBoMon>();

    [InverseProperty("BoMon")]
    public virtual ICollection<   MonHocThuocBoMon>    MonHocThuocBoMons { get; set; } = new List<   MonHocThuocBoMon>();
}
