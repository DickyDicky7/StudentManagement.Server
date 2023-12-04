using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("khoa_hoc")]
public partial class KhoaHoc
{
    [Key]
    [Column("ma_khoa_hoc")]
    public long MaKhoaHoc { get; set; }

    [Column("ten_khoa_hoc")]
    public string TenKhoaHoc { get; set; } = null!;

    [Column("ma_co_van_hoc_tap")]
    public long MaCoVanHocTap { get; set; }

    [Column("ten_lop_sinh_hoat_chung")]
    public string TenLopSinhHoatChung { get; set; } = null!;

    [ForeignKey("MaCoVanHocTap")]
    [InverseProperty("KhoaHocs")]
    public virtual GiangVien CoVanHocTap { get; set; } = null!;

    [InverseProperty("KhoaHoc")]
    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
