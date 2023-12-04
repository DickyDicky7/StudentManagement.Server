using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("he_dao_tao")]
public partial class HeDaoTao
{
    [Key]
    [Column("ma_he_dao_tao")]
    public long MaHeDaoTao { get; set; }

    [Column("ten_he_dao_tao")]
    public string TenHeDaoTao { get; set; } = null!;

    [InverseProperty("HeDaoTao")]
    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    [InverseProperty("HeDaoTao")]
    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
