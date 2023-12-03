using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("thong_tin_hoc_phi")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "thong_tin_hoc_phi_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
[Index("MaThongTinHocPhiHocKyTruoc", Name = "thong_tin_hoc_phi_unique_ma_thong_tin_hoc_phi_hoc_ky_truoc", IsUnique = true)]
public partial class ThongTinHocPhi
{
    [Key]
    [Column("ma_thong_tin_hoc_phi")]
    public long MaThongTinHocPhi { get; set; }

    [Column("so_tien_hoc_phi_theo_quy_dinh", TypeName = "money")]
    public decimal SoTienHocPhiTheoQuyDinh { get; set; }

    [Column("so_tien_phai_dong", TypeName = "money")]
    public decimal SoTienPhaiDong { get; set; }

    [Column("so_tien_da_dong", TypeName = "money")]
    public decimal SoTienDaDong { get; set; }

    [Column("so_tien_du", TypeName = "money")]
    public decimal SoTienDu { get; set; }

    [Column("ten_ngan_hang_thanh_toan_hoc_phi")]
    public string TenNganHangThanhToanHocPhi { get; set; } = null!;

    [Column("thoi_diem_thanh_toan_hoc_phi")]
    public DateTime ThoiDiemThanhToanHocPhi { get; set; }

    [Column("ghi_chu_bo_sung")]
    public string GhiChuBoSung { get; set; } = null!;

    [Column("ma_thong_tin_hoc_phi_hoc_ky_truoc")]
    public long? MaThongTinHocPhiHocKyTruoc { get; set; }

    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [InverseProperty("MaThongTinHocPhiNavigation")]
    public virtual ThongTinHocPhi? InverseMaThongTinHocPhiNavigation { get; set; }

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("ThongTinHocPhis")]
    public virtual HocKyNamHoc MaHocKyNamHocNavigation { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("ThongTinHocPhis")]
    public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;

    [ForeignKey("MaThongTinHocPhi")]
    [InverseProperty("InverseMaThongTinHocPhiNavigation")]
    public virtual ThongTinHocPhi MaThongTinHocPhiNavigation { get; set; } = null!;

    [InverseProperty("MaThongTinHocPhiNavigation")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();
}
