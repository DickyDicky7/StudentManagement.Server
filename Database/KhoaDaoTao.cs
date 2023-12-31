﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("khoa_dao_tao")]
public partial class KhoaDaoTao
{
    [Key]
    [Column("ma_khoa_dao_tao")]
    public long    MaKhoaDaoTao { get; set; }

    [Column("ten_khoa_dao_tao")]
    public string TenKhoaDaoTao { get; set; } = null!;

    [InverseProperty("KhoaDaoTao")]
    public virtual ICollection<ChuyenNganh             > ChuyenNganhs              { get; set; } = new List<ChuyenNganh             >();

    [InverseProperty("KhoaDaoTao")]
    public virtual ICollection<GiangVienThuocKhoaDaoTao> GiangVienThuocKhoaDaoTaos { get; set; } = new List<GiangVienThuocKhoaDaoTao>();

    [InverseProperty("KhoaDaoTao")]
    public virtual ICollection<   MonHocThuocKhoaDaoTao>    MonHocThuocKhoaDaoTaos { get; set; } = new List<   MonHocThuocKhoaDaoTao>();
}
