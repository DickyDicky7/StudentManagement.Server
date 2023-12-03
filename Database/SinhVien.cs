using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("sinh_vien")]
public partial class SinhVien
{
    [Key]
    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [Column("ho_ten_sinh_vien")]
    public string HoTenSinhVien { get; set; } = null!;

    [Column("ma_khoa_hoc")]
    public long MaKhoaHoc { get; set; }

    [Column("ma_chuyen_nganh")]
    public long MaChuyenNganh { get; set; }

    [Column("ma_he_dao_tao")]
    public long MaHeDaoTao { get; set; }

    [Column("tinh_trang_hoc_tap")]
    public string TinhTrangHocTap { get; set; } = null!;

    [Column("ngay_sinh")]
    public DateOnly NgaySinh { get; set; }

    [Column("gioi_tinh")]
    public string GioiTinh { get; set; } = null!;

    [Column("email")]
    public string Email { get; set; } = null!;

    [Column("email_password")]
    public string EmailPassword { get; set; } = null!;

    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("username_password")]
    public string UsernamePassword { get; set; } = null!;

    [Column("so_tai_khoan_ngan_hang_dinh_danh")]
    public string SoTaiKhoanNganHangDinhDanh { get; set; } = null!;

    [Column("anh_the_sinh_vien")]
    public string AnhTheSinhVien { get; set; } = null!;

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<BangDiemHocPhan> BangDiemHocPhans { get; set; } = new List<BangDiemHocPhan>();

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<HoSo> HoSos { get; set; } = new List<HoSo>();

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<KetQuaHocTap> KetQuaHocTaps { get; set; } = new List<KetQuaHocTap>();

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<KetQuaRenLuyen> KetQuaRenLuyens { get; set; } = new List<KetQuaRenLuyen>();

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<KhenThuong> KhenThuongs { get; set; } = new List<KhenThuong>();

    [ForeignKey("MaChuyenNganh")]
    [InverseProperty("SinhViens")]
    public virtual ChuyenNganh MaChuyenNganhNavigation { get; set; } = null!;

    [ForeignKey("MaHeDaoTao")]
    [InverseProperty("SinhViens")]
    public virtual HeDaoTao MaHeDaoTaoNavigation { get; set; } = null!;

    [ForeignKey("MaKhoaHoc")]
    [InverseProperty("SinhViens")]
    public virtual KhoaHoc MaKhoaHocNavigation { get; set; } = null!;

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();

    [InverseProperty("MaSinhVienNavigation")]
    public virtual ICollection<ThongTinHocPhi> ThongTinHocPhis { get; set; } = new List<ThongTinHocPhi>();
}
