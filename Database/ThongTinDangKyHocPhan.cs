using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("thong_tin_dang_ky_hoc_phan")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "thong_tin_dang_ky_hoc_phan_unique", IsUnique = true)]
public partial class ThongTinDangKyHocPhan
{
    [Key]
    [Column("ma_thong_tin_dang_ky_hoc_phan")]
    public long MaThongTinDangKyHocPhan { get; set; }

    [Column("ma_hoc_ky_nam_hoc")]
    public long? MaHocKyNamHoc { get; set; }

    [Column("ma_sinh_vien")]
    public long? MaSinhVien { get; set; }

    [InverseProperty("ThongTinDangKyHocPhan")]
    public virtual ICollection<DanhSachDangKyHocPhan> DanhSachDangKyHocPhans { get; set; } = new List<DanhSachDangKyHocPhan>();

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("ThongTinDangKyHocPhans")]
    public virtual HocKyNamHoc? HocKyNamHoc { get; set; }

    [ForeignKey("MaSinhVien")]
    [InverseProperty("ThongTinDangKyHocPhans")]
    public virtual SinhVien? SinhVien { get; set; }

    [InverseProperty("ThongTinDangKyHocPhan")]
    public virtual ThongTinHocKyNamHoc? ThongTinHocKyNamHoc { get; set; }
}
