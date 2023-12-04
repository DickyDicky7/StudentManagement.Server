using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("hoc_ky_nam_hoc")]
[Index("TenHocKy", "TenNamHoc", Name = "hoc_ky_nam_hoc_unique_ten_hoc_ky_ten_nam_hoc", IsUnique = true)]
public partial class HocKyNamHoc
{
    [Key]
    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ten_hoc_ky")]
    public string TenHocKy { get; set; } = null!;

    [Column("ten_nam_hoc")]
    public string TenNamHoc { get; set; } = null!;

    [InverseProperty("HocKyNamHoc")]
    public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();

    [InverseProperty("HocKyNamHoc")]
    public virtual ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; } = new List<KetQuaHocTap>();

    [InverseProperty("HocKyNamHoc")]
    public virtual ICollection<KetQuaRenLuyen> KetQuaRenLuyens { get; set; } = new List<KetQuaRenLuyen>();

    [InverseProperty("HocKyNamHoc")]
    public virtual ICollection<KhenThuong> KhenThuongs { get; set; } = new List<KhenThuong>();

    [InverseProperty("HocKyNamHoc")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();

    [InverseProperty("HocKyNamHoc")]
    public virtual ICollection<ThongTinHocPhi> ThongTinHocPhis { get; set; } = new List<ThongTinHocPhi>();
}
