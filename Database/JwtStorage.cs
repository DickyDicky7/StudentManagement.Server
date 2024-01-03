using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[PrimaryKey("MaSinhVienHoacNhanVien", "Loai")]
[Table("jwt_storage")]
public partial class JwtStorage
{
    [Key]
    [Column("ma_sinh_vien_hoac_nhan_vien")]
    public long MaSinhVienHoacNhanVien { get; set; }

    [Key]
    [Column("loai")]
    public string Loai { get; set; } = null!;

    [Column("access_token")]
    public string AccessToken { get; set; } = null!;

    [Column("refresh_token")]
    public string RefreshToken { get; set; } = null!;
}
