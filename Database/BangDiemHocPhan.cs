using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("bang_diem_hoc_phan")]
[Index("MaHocPhan", "MaSinhVien", Name = "bang_diem_hoc_phan_unique_ma_hoc_phan_ma_sinh_vien", IsUnique = true)]
public partial class BangDiemHocPhan
{
    [Key]
    [Column("ma_bang_diem_hoc_phan")]
    public long MaBangDiemHocPhan { get; set; }

    [Column("ma_hoc_phan")]
    public long MaHocPhan { get; set; }

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [Column("diem_qua_trinh")]
    public float DiemQuaTrinh { get; set; }

    [Column("diem_giua_ky")]
    public float? DiemGiuaKy { get; set; }

    [Column("diem_thuc_hanh")]
    public float? DiemThucHanh { get; set; }

    [Column("diem_cuoi_ky")]
    public float DiemCuoiKy { get; set; }

    [InverseProperty("BangDiemHocPhan")]
    public virtual DanhSachDangKyHocPhan? DanhSachDangKyHocPhan { get; set; }

    [ForeignKey("MaHocPhan")]
    [InverseProperty("BangDiemHocPhans")]
    public virtual HocPhan HocPhan { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("BangDiemHocPhans")]
    public virtual SinhVien SinhVien { get; set; } = null!;
}
