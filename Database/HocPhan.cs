using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("hoc_phan")]
public partial class HocPhan
{
    [Key]
    [Column("ma_hoc_phan")]
    public long MaHocPhan { get; set; }

    [Column("ma_mon_hoc")]
    public long MaMonHoc { get; set; }

    [Column("ma_he_dao_tao")]
    public long MaHeDaoTao { get; set; }

    [Column("hinh_thuc_thi")]
    public string HinhThucThi { get; set; } = null!;

    [Column("loai_hoc_phan")]
    public string LoaiHocPhan { get; set; } = null!;

    [Column("ma_giang_vien")]
    public long MaGiangVien { get; set; }

    [Column("si_so_sinh_vien")]
    public short SiSoSinhVien { get; set; }

    [Column("thoi_diem_bat_dau")]
    public DateOnly ThoiDiemBatDau { get; set; }

    [Column("thoi_diem_ket_thuc")]
    public DateOnly ThoiDiemKetThuc { get; set; }

    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ghi_chu")]
    public string GhiChu { get; set; } = null!;

    [InverseProperty("MaHocPhanNavigation")]
    public virtual ICollection<BangDiemHocPhan> BangDiemHocPhans { get; set; } = new List<BangDiemHocPhan>();

    [InverseProperty("MaHocPhanNavigation")]
    public virtual ICollection<DanhSachDangKyHocPhan> DanhSachDangKyHocPhans { get; set; } = new List<DanhSachDangKyHocPhan>();

    [ForeignKey("MaGiangVien")]
    [InverseProperty("HocPhans")]
    public virtual GiangVien MaGiangVienNavigation { get; set; } = null!;

    [ForeignKey("MaHeDaoTao")]
    [InverseProperty("HocPhans")]
    public virtual HeDaoTao MaHeDaoTaoNavigation { get; set; } = null!;

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("HocPhans")]
    public virtual HocKyNamHoc MaHocKyNamHocNavigation { get; set; } = null!;

    [ForeignKey("MaMonHoc")]
    [InverseProperty("HocPhans")]
    public virtual MonHoc MaMonHocNavigation { get; set; } = null!;
}
