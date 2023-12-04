using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

[Table("ket_qua_ren_luyen")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "ket_qua_ren_luyen_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
public partial class KetQuaRenLuyen
{
    [Key]
    [Column("ma_ket_qua_ren_luyen")]
    public long MaKetQuaRenLuyen { get; set; }

    [Column("so_diem_ren_luyen")]
    public short SoDiemRenLuyen { get; set; }

    [Column("xep_loai_ren_luyen")]
    public string XepLoaiRenLuyen { get; set; } = null!;

    [Column("ma_hoc_ky_nam_hoc")]
    public long MaHocKyNamHoc { get; set; }

    [Column("ma_sinh_vien")]
    public long MaSinhVien { get; set; }

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("KetQuaRenLuyens")]
    public virtual HocKyNamHoc HocKyNamHoc { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("KetQuaRenLuyens")]
    public virtual SinhVien SinhVien { get; set; } = null!;

    [InverseProperty("KetQuaRenLuyen")]
    public virtual ICollection<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; } = new List<ThongTinHocKyNamHoc>();
}
