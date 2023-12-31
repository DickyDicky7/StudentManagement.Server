using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("giang_vien")]
public partial class GiangVien
{
    [Key]
    [Column("ma_giang_vien")]
    public long MaGiangVien { get; set; }

    [Column("ten_giang_vien")]
    public string TenGiangVien { get; set; } = null!;

    [InverseProperty("GiangVien")]
    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    [InverseProperty("CoVanHocTap")]
    public virtual ICollection<KhoaHoc> KhoaHocs { get; set; } = new List<KhoaHoc>();
}
