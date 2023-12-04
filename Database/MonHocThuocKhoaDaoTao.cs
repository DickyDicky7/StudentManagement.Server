using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("mon_hoc_thuoc_khoa_dao_tao")]
public partial class MonHocThuocKhoaDaoTao
{
    [Key]
    [Column("ma_mon_hoc")]
    public long MaMonHoc { get; set; }

    [Column("ma_khoa_dao_tao")]
    public long MaKhoaDaoTao { get; set; }

    [ForeignKey("MaKhoaDaoTao")]
    [InverseProperty("MonHocThuocKhoaDaoTaos")]
    public virtual KhoaDaoTao KhoaDaoTao { get; set; } = null!;

    [ForeignKey("MaMonHoc")]
    [InverseProperty("MonHocThuocKhoaDaoTao")]
    public virtual MonHoc MonHoc { get; set; } = null!;
}
