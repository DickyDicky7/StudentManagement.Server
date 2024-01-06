using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Server.Database;

[Table("thong_tin_hoc_ky_nam_hoc")]
[Index("MaHocKyNamHoc", "MaSinhVien", Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_hoc_ky_nam_hoc_ma_sinh_vien", IsUnique = true)]
[Index("MaKetQuaHocTap"             , Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_ket_qua_hoc_tap"            , IsUnique = true)]
[Index("MaKetQuaRenLuyen"           , Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_ket_qua_ren_luyen"          , IsUnique = true)]
[Index("MaKhenThuong"               , Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_khen_thuong"                , IsUnique = true)]
[Index("MaThongTinDangKyHocPhan"    , Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_thong_tin_dang_ky_hoc_phan" , IsUnique = true)]
[Index("MaThongTinHocPhi"           , Name = "thong_tin_hoc_ky_nam_hoc_unique_ma_thong_tin_hoc_phi"          , IsUnique = true)]
public partial class ThongTinHocKyNamHoc
{
    [Key]
    [Column("ma_thong_tin_hoc_ky_nam_hoc")]
    public long  MaThongTinHocKyNamHoc      { get; set; }

    [Column("ma_hoc_ky_nam_hoc")]
    public long  MaHocKyNamHoc              { get; set; }

    [Column("ma_sinh_vien")]
    public long  MaSinhVien                 { get; set; }

    [Column("ma_thong_tin_dang_ky_hoc_phan")]
    public long  MaThongTinDangKyHocPhan    { get; set; }

    [Column("ma_ket_qua_hoc_tap")]
    public long  MaKetQuaHocTap             { get; set; }

    [Column("ma_ket_qua_ren_luyen")]
    public long  MaKetQuaRenLuyen           { get; set; }

    [Column("ma_khen_thuong")]
    public long  MaKhenThuong               { get; set; }

    [Column("ma_thong_tin_hoc_phi")]
    public long  MaThongTinHocPhi           { get; set; }

    [Column("ma_thong_tin_hoc_ky_nam_hoc_truoc")]
    public long? MaThongTinHocKyNamHocTruoc { get; set; }

    [ForeignKey("MaHocKyNamHoc")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual HocKyNamHoc  HocKyNamHoc { get; set; } = null!;

    [InverseProperty("ThongTinHocKyNamHocTruoc")]
    public virtual ICollection<ThongTinHocKyNamHoc> InverseThongTinHocKyNamHocTruoc { get; set; } = new List<ThongTinHocKyNamHoc>();

    [ForeignKey("MaKetQuaHocTap")]
    [InverseProperty("ThongTinHocKyNamHoc")]
    public virtual KetQuaHocTap          KetQuaHocTap             { get; set; } = null!;

    [ForeignKey("MaKetQuaRenLuyen")]
    [InverseProperty("ThongTinHocKyNamHoc")]
    public virtual KetQuaRenLuyen        KetQuaRenLuyen           { get; set; } = null!;

    [ForeignKey("MaKhenThuong")]
    [InverseProperty("ThongTinHocKyNamHoc")]
    public virtual KhenThuong            KhenThuong               { get; set; } = null!;

    [ForeignKey("MaSinhVien")]
    [InverseProperty("ThongTinHocKyNamHocs")]
    public virtual SinhVien              SinhVien                 { get; set; } = null!;

    [ForeignKey ("MaThongTinDangKyHocPhan")]
    [InverseProperty("ThongTinHocKyNamHoc")]
    public virtual ThongTinDangKyHocPhan ThongTinDangKyHocPhan    { get; set; } = null!;

    [ForeignKey("MaThongTinHocKyNamHocTruoc")]
    [InverseProperty("InverseThongTinHocKyNamHocTruoc")]
    public virtual ThongTinHocKyNamHoc?  ThongTinHocKyNamHocTruoc { get; set; }

    [ForeignKey("MaThongTinHocPhi")]
    [InverseProperty("ThongTinHocKyNamHoc")]
    public virtual ThongTinHocPhi        ThongTinHocPhi           { get; set; } = null!;
}
