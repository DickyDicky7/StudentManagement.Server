using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("giang_vien")]
public partial class GiangVien
{
    [Key]
    [Column("ma_giang_vien")]
    public long MaGiangVien { get; set; }

    [Column("ten_giang_vien")]
    public string TenGiangVien { get; set; } = null!;

    [InverseProperty("MaGiangVienNavigation")]
    public virtual GiangVienThuocBoMon? GiangVienThuocBoMon { get; set; }

    [InverseProperty("MaGiangVienNavigation")]
    public virtual GiangVienThuocKhoaDaoTao? GiangVienThuocKhoaDaoTao { get; set; }

    [InverseProperty("MaGiangVienNavigation")]
    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    [InverseProperty("MaCoVanHocTapNavigation")]
    public virtual ICollection<KhoaHoc> KhoaHocs { get; set; } = new List<KhoaHoc>();
}
