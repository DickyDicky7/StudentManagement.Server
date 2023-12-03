using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("thong_tin_hoc_ky_nam_hoc")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
public partial class ThongTinHocKyNamHoc
{
    [Key]
    [Column("ma_thong_tin_hoc_ky_nam_hoc")]
    public long MaThongTinHocKyNamHoc { get; set; }

    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [Column("ma_thong_tin_dang_ky_hoc_phan")]
    public long MaThongTinDangKyHocPhan { get; set; }

    [Column("ma_ket_qua_hoc_tap")]
    public long MaKetQuaHocTap { get; set; }

    [Column("ma_ket_qua_ren_luyen")]
    public long MaKetQuaRenLuyen { get; set; }

    [Column("ma_khen_thuong")]
    public long MaKhenThuong { get; set; }

    [Column("ma_thong_tin_hoc_phi")]
    public long MaThongTinHocPhi { get; set; }

    [Column("ma_thong_tin_hoc_ky_nam_hoc_truoc")]
    public long? MaThongTinHocKyNamHocTruoc { get; set; }

    [InverseProperty("MaThongTinHocKyNamHocTruocNavigation")]
    public virtual ICollection<ThongTinHocKyNamHoc> InverseMaThongTinHocKyNamHocTruocNavigation { get; set; } = new List<ThongTinHocKyNamHoc>();

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual HocKyNamHoc MaHocKyNamHocNavigation { get; set; } = null!;

    [ForeignKey("MaKetQuaHocTap")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual KetQuaHocTap MaKetQuaHocTapNavigation { get; set; } = null!;

    [ForeignKey("MaKetQuaRenLuyen")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual KetQuaRenLuyen MaKetQuaRenLuyenNavigation { get; set; } = null!;

    [ForeignKey("MaKhenThuong")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual KhenThuong MaKhenThuongNavigation { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;

    [ForeignKey("MaThongTinDangKyHocPhan")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual ThongTinDangKyHocPhan MaThongTinDangKyHocPhanNavigation { get; set; } = null!;

    [ForeignKey("MaThongTinHocKyNamHocTruoc")]
    [InverseProperty("InverseMaThongTinHocKyNamHocTruocNavigation")]
    public virtual ThongTinHocKyNamHoc? MaThongTinHocKyNamHocTruocNavigation { get; set; }

    [ForeignKey("MaThongTinHocPhi")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual ThongTinHocPhi MaThongTinHocPhiNavigation { get; set; } = null!;
}
