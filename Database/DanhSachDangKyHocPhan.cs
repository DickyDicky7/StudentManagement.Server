using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[PrimaryKey("MaThongTinDangKyHocPhan", "MaHocPhan")]
[Table("danh_sach_dang_ky_hoc_phan")]
[Index("MaBangDiemHocPhan", Name = "danh_sach_dang_ky_hoc_phan_unique_ma_bang_diem_hoc_phan", IsUnique = true)]
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
    [InverseProperty("DanhSachDangKyHocPhan")]
    public virtual BangDiemHocPhan BangDiemHocPhan { get; set; } = null!;

    [ForeignKey("MaHocPhan")]
    [InverseProperty("DanhSachDangKyHocPhans")]
    public virtual HocPhan HocPhan { get; set; } = null!;

    [ForeignKey("MaThongTinDangKyHocPhan")]
    [InverseProperty("DanhSachDangKyHocPhans")]
    public virtual ThongTinDangKyHocPhan ThongTinDangKyHocPhan { get; set; } = null!;
}
