using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[PrimaryKey("MaThongTinDangKyHocPhan", "MaHocPhan")]
[Table("danh_sach_dang_ky_hoc_phan")]
public partial class DanhSachDangKyHocPhan
{
    [Key]
    [Column("ma_thong_tin_dang_ky_hoc_phan")]
    public long MaThongTinDangKyHocPhan { get; set; }

    [Key]
    [Column("ma_hoc_phan")]
    public long MaHocPhan { get; set; }

    [Column("hoc_lai_hay_hoc_cai_thien")]
    public bool HocLaiHayHocCaiThien { get; set; }

    [Column("ma_bang_diem_hoc_phan")]
    public long MaBangDiemHocPhan { get; set; }

    [ForeignKey("MaBangDiemHocPhan")]
    [InverseProperty("DanhSachDangKyHocPhans")]
    public virtual BangDiemHocPhan MaBangDiemHocPhanNavigation { get; set; } = null!;

    [ForeignKey("MaHocPhan")]
    [InverseProperty("DanhSachDangKyHocPhans")]
    public virtual HocPhan MaHocPhanNavigation { get; set; } = null!;

    [ForeignKey("MaThongTinDangKyHocPhan")]
    [InverseProperty("DanhSachDangKyHocPhans")]
    public virtual ThongTinDangKyHocPhan MaThongTinDangKyHocPhanNavigation { get; set; } = null!;
}
