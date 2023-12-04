using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("mon_hoc")]
public abstract partial class MonHoc
{
	[Key]
	[Column("ma_mon_hoc")]
	public long MaMonHoc { get; set; }

	[Column("ten_mon_hoc")]
	public string TenMonHoc { get; set; } = null!;

	[Column("con_mo_lop")]
	public bool ConMoLop { get; set; }

	[Column("loai_mon_hoc")]
	public string LoaiMonHoc { get; set; } = null!;

	[Column("danh_sach_ma_mon_hoc_tien_quyet")]
	public string[] DanhSachMaMonHocTienQuyet { get; set; } = null!;

	[Column("so_tin_chi_ly_thuyet")]
	public short SoTinChiLyThuyet { get; set; }

	[Column("so_tin_chi_thuc_hanh")]
	public short SoTinChiThucHanh { get; set; }

	[Column("tom_tat_mon_hoc")]
	public string TomTatMonHoc { get; set; } = null!;

	[InverseProperty("MonHoc")]
	public virtual ICollection<HocPhan> HocPhans { get; set; } = new List<HocPhan>();
}
