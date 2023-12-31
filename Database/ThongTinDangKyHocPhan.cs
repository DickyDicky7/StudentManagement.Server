using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("thong_tin_dang_ky_hoc_phan")]
public partial class ThongTinDangKyHocPhan
{
    [Key]
    [Column("ma_thong_tin_dang_ky_hoc_phan")]
    public long MaThongTinDangKyHocPhan { get; set; }

    [InverseProperty("ThongTinDangKyHocPhan")]
    public virtual ICollection<DanhSachDangKyHocPhan> DanhSachDangKyHocPhans { get; set; } = new List<DanhSachDangKyHocPhan>();

    [InverseProperty("ThongTinDangKyHocPhan")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();
}
