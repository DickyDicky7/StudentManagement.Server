using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("ket_qua_hoc_tap")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "ket_qua_hoc_tap_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
public partial class KetQuaHocTap
{
    [Key]
    [Column("ma_ket_qua_hoc_tap")]
    public long MaKetQuaHocTap { get; set; }

    [Column("diem_trung_binh_hoc_ky")]
    public float DiemTrungBinhHocKy { get; set; }

    [Column("xep_loai_hoc_tap")]
    public string XepLoaiHocTap { get; set; } = null!;

    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("KetQuaHocTaps")]
    public virtual HocKyNamHoc MaHocKyNamHocNavigation { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("KetQuaHocTaps")]
    public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;

    [InverseProperty("MaKetQuaHocTapNavigation")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();
}
