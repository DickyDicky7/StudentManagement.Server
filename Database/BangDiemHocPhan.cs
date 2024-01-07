using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("bang_diem_hoc_phan")]
[Index("MaHocPhan", "MaSinhVien", Name = "bang_diem_hoc_phan_unique_ma_hoc_phan_ma_sinh_vien", IsUnique = true)]
public partial class BangDiemHocPhan
{
    [Key]
    [Column("ma_bang_diem_hoc_phan")]
    public long    MaBangDiemHocPhan { get; set; }

    [Column("ma_hoc_phan")]
    public long    MaHocPhan         { get; set; }

    [Column("ma_sinh_vien")]
    public long    MaSinhVien        { get; set; }

    [Column("diem_qua_trinh")]
    public decimal DiemQuaTrinh      { get; set; }

    [Column("diem_giua_ky")]
    public decimal DiemGiuaKy        { get; set; }

    [Column("diem_thuc_hanh")]
    public decimal DiemThucHanh      { get; set; }

    [Column("diem_cuoi_ky")]
    public decimal DiemCuoiKy        { get; set; }

    [Column("diem_tong")]
    public decimal DiemTong          { get; set; }

    [InverseProperty("BangDiemHocPhan")]
    public virtual DanhSachDangKyHocPhan? DanhSachDangKyHocPhan { get; set; }

    [ForeignKey("MaHocPhan")]
    [InverseProperty("BangDiemHocPhans")]
    public virtual HocPhan                HocPhan               { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("BangDiemHocPhans")]
    public virtual SinhVien               SinhVien              { get; set; } = null!;
}

// Công thức
// học phần lý thuyết: tổng điểm = 25%QT + 25%GK + 50% CK (TH để 0)
// học phần thực hành: tổng điểm = 100%TH (QT, GK, CK để 0)
// Điểm tổng của môn = 50% tổng điểm lt + 50% tổng điểm th