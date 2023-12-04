using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("khen_thuong")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "khen_thuong_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
public partial class KhenThuong
{
    [Key]
    [Column("ma_khen_thuong")]
    public long MaKhenThuong { get; set; }

    [Column("xep_loai_khen_thuong")]
    public string XepLoaiKhenThuong { get; set; } = null!;

    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("KhenThuongs")]
    public virtual HocKyNamHoc HocKyNamHoc { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("KhenThuongs")]
    public virtual SinhVien SinhVien { get; set; } = null!;

    [InverseProperty("KhenThuong")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();
}
