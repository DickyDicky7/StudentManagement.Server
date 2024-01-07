using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("hoc_phan")]
public partial class HocPhan
{
    [Key]
    [Column("ma_hoc_phan")]
    public long     MaHocPhan       { get; set; }

    [Column("ma_mon_hoc")]
    public long     MaMonHoc        { get; set; }

    [Column("ma_he_dao_tao")]
    public long     MaHeDaoTao      { get; set; }

    [Column("hinh_thuc_thi")]
    public string   HinhThucThi     { get; set; } = null!;

    [Column("loai_hoc_phan")]
    public string   LoaiHocPhan     { get; set; } = null!;

    [Column("ma_giang_vien")]
    public long     MaGiangVien     { get; set; }

    [Column("si_so_sinh_vien")]
    public short    SiSoSinhVien    { get; set; }

    [Column("thoi_diem_bat_dau")]
    public DateTime ThoiDiemBatDau  { get; set; }

    [Column("thoi_diem_ket_thuc")]
    public DateTime ThoiDiemKetThuc { get; set; }

    [Column("ma_hoc_ky_nam_hoc")]
    public long     MaHocKyNamHoc   { get; set; }

    [Column("ghi_chu")]
    public string   GhiChu          { get; set; } = null!;

    [InverseProperty("HocPhan")]
    public virtual ICollection<      BangDiemHocPhan>       BangDiemHocPhans { get; set; } = new List<      BangDiemHocPhan>();

    [InverseProperty("HocPhan")]
    public virtual ICollection<BuoiHoc> BuoiHocs { get; set; } = new List<BuoiHoc>();

    [InverseProperty("HocPhan")]
    public virtual ICollection<BuoiThi> BuoiThis { get; set; } = new List<BuoiThi>();

    [InverseProperty("HocPhan")]
    public virtual ICollection<DanhSachDangKyHocPhan> DanhSachDangKyHocPhans { get; set; } = new List<DanhSachDangKyHocPhan>();

    [ForeignKey("MaGiangVien")]
    [InverseProperty("HocPhans")]
    public virtual GiangVien   GiangVien   { get; set; } = null!;

    [ForeignKey("MaHeDaoTao")]
    [InverseProperty("HocPhans")]
    public virtual HeDaoTao    HeDaoTao    { get; set; } = null!;

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("HocPhans")]
    public virtual HocKyNamHoc HocKyNamHoc { get; set; } = null!;

    [ForeignKey("MaMonHoc")]
    [InverseProperty("HocPhans")]
    public virtual MonHoc      MonHoc      { get; set; } = null!;
}

