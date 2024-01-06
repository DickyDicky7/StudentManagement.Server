using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("giang_vien_thuoc_khoa_dao_tao")]
public partial class GiangVienThuocKhoaDaoTao : GiangVien
{
    [Column("ma_khoa_dao_tao")]
    public long  MaKhoaDaoTao { get; set; }

    [ForeignKey("MaKhoaDaoTao")]
    [InverseProperty("GiangVienThuocKhoaDaoTaos")]
    public virtual KhoaDaoTao KhoaDaoTao { get; set; } = null!;
}
