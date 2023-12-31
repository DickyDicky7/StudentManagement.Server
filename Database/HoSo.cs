using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("ho_so")]
public partial class HoSo
{
    [Key]
    [Column("ma_ho_so")]
    public long MaHoSo { get; set; }

    [Column("hoan_thanh")]
    public bool HoanThanh { get; set; }

    [Column("ghi_chu")]
    public string GhiChu { get; set; } = null!;

    [Column("loai_ho_so")]
    public string LoaiHoSo { get; set; } = null!;

    [Column("danh_sach_dinh_kem")]
    public string[] DanhSachDinhKem { get; set; } = null!;

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [ForeignKey("MaSinhVien")]
    [InverseProperty("HoSos")]
    public virtual SinhVien SinhVien { get; set; } = null!;
}
