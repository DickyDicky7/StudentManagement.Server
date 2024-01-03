using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("thong_tin_hoc_phi")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "thong_tin_hoc_phi_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
[Index("MaThongTinHocPhiHocKyTruoc", Name = "thong_tin_hoc_phi_unique_ma_thong_tin_hoc_phi_hoc_ky_truoc", IsUnique = true)]
public partial class ThongTinHocPhi
{
    [Key]
    [Column("ma_thong_tin_hoc_phi")]
    public long MaThongTinHocPhi { get; set; }

    [Column("so_tien_hoc_phi_theo_quy_dinh")]
    public decimal SoTienHocPhiTheoQuyDinh { get; set; }

    [Column("so_tien_phai_dong")]
    public decimal SoTienPhaiDong { get; set; }

    [Column("so_tien_da_dong")]
    public decimal SoTienDaDong { get; set; }

    [Column("so_tien_du")]
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

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("ThongTinHocPhis")]
    public virtual HocKyNamHoc HocKyNamHoc { get; set; } = null!;

    [InverseProperty("ThongTinHocPhiHocKyTruoc")]
    public virtual ThongTinHocPhi? InverseThongTinHocPhiHocKyTruoc { get; set; }

    [ForeignKey("MaSinhVien")]
    [InverseProperty("ThongTinHocPhis")]
    public virtual SinhVien SinhVien { get; set; } = null!;

    [InverseProperty("ThongTinHocPhi")]
    public virtual ThongTinHocKyNamHoc? ThongTinHocKyNamHoc { get; set; }

    [ForeignKey("MaThongTinHocPhiHocKyTruoc")]
    [InverseProperty("InverseThongTinHocPhiHocKyTruoc")]
    public virtual ThongTinHocPhi? ThongTinHocPhiHocKyTruoc { get; set; }
}
