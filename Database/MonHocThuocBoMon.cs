using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("mon_hoc_thuoc_bo_mon")]
public partial class MonHocThuocBoMon : MonHoc
{
    [Column  ("ma_bo_mon")]
    public long  MaBoMon { get; set; }

    [ForeignKey("MaBoMon")]
    [InverseProperty("MonHocThuocBoMons")]
    public virtual BoMon BoMon { get; set; } = null!;
}
