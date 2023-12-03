using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("mon_hoc_thuoc_bo_mon")]
public partial class MonHocThuocBoMon
{
    [Key]
    [Column("ma_mon_hoc")]
    public long MaMonHoc { get; set; }

    [Column("ma_bo_mon")]
    public long MaBoMon { get; set; }

    [ForeignKey("MaBoMon")]
    [InverseProperty("MonHocThuocBoMons")]
    public virtual BoMon MaBoMonNavigation { get; set; } = null!;

    [ForeignKey("MaMonHoc")]
    [InverseProperty("MonHocThuocBoMon")]
    public virtual MonHoc MaMonHocNavigation { get; set; } = null!;
}
