using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("chuyen_nganh")]
public partial class ChuyenNganh
{
    [Key]
    [Column( "ma_chuyen_nganh")]
    public long    MaChuyenNganh { get; set; }

    [Column("ten_chuyen_nganh")]
    public string TenChuyenNganh { get; set; } = null!;

    [Column("ma_khoa_dao_tao")]
    public long   MaKhoaDaoTao   { get; set; }

    [ForeignKey("MaKhoaDaoTao")]
    [InverseProperty("ChuyenNganhs")]
    public virtual KhoaDaoTao KhoaDaoTao { get; set; } = null!;

    [InverseProperty("ChuyenNganh")]
    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
