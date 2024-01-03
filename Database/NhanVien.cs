using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("nhan_vien")]
public partial class NhanVien
{
    [Key]
    [Column("ma_nhan_vien")]
    public long MaNhanVien { get; set; }

    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("username_password")]
    public string UsernamePassword { get; set; } = null!;

    [Column("ten_nhan_vien")]
    public string TenNhanVien { get; set; } = null!;
}
