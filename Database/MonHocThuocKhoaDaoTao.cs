using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("mon_hoc_thuoc_khoa_dao_tao")]
public partial class MonHocThuocKhoaDaoTao : MonHoc
{
	[Column("ma_khoa_dao_tao")]
	public long MaKhoaDaoTao { get; set; }

	[ForeignKey("MaKhoaDaoTao")]
	[InverseProperty("MonHocThuocKhoaDaoTaos")]
	public virtual KhoaDaoTao KhoaDaoTao { get; set; } = null!;
}
