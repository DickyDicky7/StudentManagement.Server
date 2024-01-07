using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("sinh_vien")]
[Index("Email", Name = "sinh_vien_unique_email", IsUnique = true)]
//[Index("Username", Name = "sinh_vien_unique_username", IsUnique = true)]
public partial class SinhVien
{
    [Key]
    [Column("ma_sinh_vien")]
    public long     MaSinhVien                 { get; set; }

    [Column("ho_ten_sinh_vien")]
    public string   HoTenSinhVien              { get; set; } = null!;

    [Column("ma_khoa_hoc")]
    public long     MaKhoaHoc                  { get; set; }

    [Column("ma_chuyen_nganh")]
    public long     MaChuyenNganh              { get; set; }

    [Column("ma_he_dao_tao")]
    public long     MaHeDaoTao                 { get; set; }

    [Column("tinh_trang_hoc_tap")]
    public string   TinhTrangHocTap            { get; set; } = null!;

    [Column("ngay_sinh")]
    public DateTime NgaySinh                   { get; set; }

    [Column("gioi_tinh")]
    public string   GioiTinh                   { get; set; } = null!;

    [Column("email")]
    public string   Email                      { get; set; } = null!;

    [Column("email_password")]
    public string   EmailPassword              { get; set; } = null!;

    [Column("username")]
    public string   Username                   { get; set; } = null!;

    [Column("username_password")]
    public string   UsernamePassword           { get; set; } = null!;

    [Column("so_tai_khoan_ngan_hang_dinh_danh")]
    public string   SoTaiKhoanNganHangDinhDanh { get; set; } = null!;

    [Column("anh_the_sinh_vien")]
    public string   AnhTheSinhVien             { get; set; } = null!;

    [Column("ngay_nhap_hoc")]
    public DateTime NgayNhapHoc                { get; set; }

    [InverseProperty("SinhVien")]
    public virtual ICollection<BangDiemHocPhan> BangDiemHocPhans { get; set; } = new List<BangDiemHocPhan>();

    [ForeignKey ("MaChuyenNganh")]
    [InverseProperty("SinhViens")]
    public virtual ChuyenNganh ChuyenNganh { get; set; } = null!;

    [ForeignKey("MaHeDaoTao")]
    [InverseProperty("SinhViens")]
    public virtual HeDaoTao    HeDaoTao    { get; set; } = null!;

    [InverseProperty("SinhVien")]
    public virtual ICollection<HoSo          > HoSos           { get; set; } = new List<HoSo          >();

    [InverseProperty("SinhVien")]
    public virtual ICollection<KetQuaHocTap  > KetQuaHocTaps   { get; set; } = new List<KetQuaHocTap  >();

    [InverseProperty("SinhVien")]
    public virtual ICollection<KetQuaRenLuyen> KetQuaRenLuyens { get; set; } = new List<KetQuaRenLuyen>();

    [InverseProperty("SinhVien")]
    public virtual ICollection<KhenThuong    > KhenThuongs     { get; set; } = new List<KhenThuong    >();

    [ForeignKey("MaKhoaHoc")]
    [InverseProperty("SinhViens")]
    public virtual KhoaHoc KhoaHoc { get; set; } = null!;

    [InverseProperty("SinhVien")]
    public virtual ICollection<ThongTinDangKyHocPhan> ThongTinDangKyHocPhans { get; set; } = new List<ThongTinDangKyHocPhan>();

    [InverseProperty("SinhVien")]
    public virtual ICollection<ThongTinHocKyNamHoc  > ThongTinHocKyNamHocs   { get; set; } = new List<ThongTinHocKyNamHoc  >();

    [InverseProperty("SinhVien")]
    public virtual ICollection<ThongTinHocPhi       > ThongTinHocPhis        { get; set; } = new List<ThongTinHocPhi       >();
}
