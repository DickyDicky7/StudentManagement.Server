﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Server.Database;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangDiemHocPhan> BangDiemHocPhans { get; set; }

    public virtual DbSet<BoMon> BoMons { get; set; }

    public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }

    public virtual DbSet<DanhSachDangKyHocPhan> DanhSachDangKyHocPhans { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<GiangVienThuocBoMon> GiangVienThuocBoMons { get; set; }

    public virtual DbSet<GiangVienThuocKhoaDaoTao> GiangVienThuocKhoaDaoTaos { get; set; }

    public virtual DbSet<HeDaoTao> HeDaoTaos { get; set; }

    public virtual DbSet<HoSo> HoSos { get; set; }

    public virtual DbSet<HocKyNamHoc> HocKyNamHocs { get; set; }

    public virtual DbSet<HocPhan> HocPhans { get; set; }

    public virtual DbSet<KetQuaHocTap> KetQuaHocTaps { get; set; }

    public virtual DbSet<KetQuaRenLuyen> KetQuaRenLuyens { get; set; }

    public virtual DbSet<KhenThuong> KhenThuongs { get; set; }

    public virtual DbSet<KhoaDaoTao> KhoaDaoTaos { get; set; }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<MonHocThuocBoMon> MonHocThuocBoMons { get; set; }

    public virtual DbSet<MonHocThuocKhoaDaoTao> MonHocThuocKhoaDaoTaos { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<ThongTinDangKyHocPhan> ThongTinDangKyHocPhans { get; set; }

    public virtual DbSet<ThongTinHocKyNamHoc> ThongTinHocKyNamHocs { get; set; }

    public virtual DbSet<ThongTinHocPhi> ThongTinHocPhis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=ep-polished-meadow-59893880.ap-southeast-1.aws.neon.tech;Port=5432;User Id=tuan.pham1973;Password=C3IARrfNS7no;Database=student_management;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangDiemHocPhan>(entity =>
        {
            entity.HasKey(e => e.MaBangDiemHocPhan).HasName("bang_diem_hoc_phan_pkey");

            entity.HasOne(d => d.MaHocPhanNavigation).WithMany(p => p.BangDiemHocPhans).HasConstraintName("bang_diem_hoc_phan_fkey_ma_hoc_phan");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.BangDiemHocPhans).HasConstraintName("bang_diem_hoc_phan_fkey_ma_sinh_vien");
        });

        modelBuilder.Entity<BoMon>(entity =>
        {
            entity.HasKey(e => e.MaBoMon).HasName("bo_mon_pkey");
        });

        modelBuilder.Entity<ChuyenNganh>(entity =>
        {
            entity.HasKey(e => e.MaChuyenNganh).HasName("chuyen_nganh_pkey");

            entity.HasOne(d => d.MaKhoaDaoTaoNavigation).WithMany(p => p.ChuyenNganhs).HasConstraintName("chuyen_nganh_fkey_ma_khoa_dao_tao");
        });

        modelBuilder.Entity<DanhSachDangKyHocPhan>(entity =>
        {
            entity.HasKey(e => new { e.MaThongTinDangKyHocPhan, e.MaHocPhan }).HasName("danh_sach_dang_ky_hoc_phan_pkey");

            entity.HasOne(d => d.MaBangDiemHocPhanNavigation).WithMany(p => p.DanhSachDangKyHocPhans).HasConstraintName("danh_sach_dang_ky_hoc_phan_fkey_ma_bang_diem_hoc_phan");

            entity.HasOne(d => d.MaHocPhanNavigation).WithMany(p => p.DanhSachDangKyHocPhans).HasConstraintName("danh_sach_dang_ky_hoc_phan_fkey_ma_hoc_phan");

            entity.HasOne(d => d.MaThongTinDangKyHocPhanNavigation).WithMany(p => p.DanhSachDangKyHocPhans).HasConstraintName("danh_sach_dang_ky_hoc_phan_fkey_ma_thong_tin_dang_ky_hoc_phan");
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.MaGiangVien).HasName("giang_vien_pkey");
        });

        modelBuilder.Entity<GiangVienThuocBoMon>(entity =>
        {
            entity.HasKey(e => e.MaGiangVien).HasName("giang_vien_thuoc_bo_mon_pkey");

            entity.Property(e => e.MaGiangVien).ValueGeneratedNever();

            entity.HasOne(d => d.MaBoMonNavigation).WithMany(p => p.GiangVienThuocBoMons).HasConstraintName("giang_vien_thuoc_bo_mon_fkey_ma_bo_mon");

            entity.HasOne(d => d.MaGiangVienNavigation).WithOne(p => p.GiangVienThuocBoMon).HasConstraintName("giang_vien_thuoc_bo_mon_fkey_ma_giang_vien");
        });

        modelBuilder.Entity<GiangVienThuocKhoaDaoTao>(entity =>
        {
            entity.HasKey(e => e.MaGiangVien).HasName("giang_vien_thuoc_khoa_dao_tao_pkey");

            entity.Property(e => e.MaGiangVien).ValueGeneratedNever();

            entity.HasOne(d => d.MaGiangVienNavigation).WithOne(p => p.GiangVienThuocKhoaDaoTao).HasConstraintName("giang_vien_thuoc_khoa_dao_tao_fkey_ma_giang_vien");

            entity.HasOne(d => d.MaKhoaDaoTaoNavigation).WithMany(p => p.GiangVienThuocKhoaDaoTaos).HasConstraintName("giang_vien_thuoc_khoa_dao_tao_fkey_ma_khoa_dao_tao");
        });

        modelBuilder.Entity<HeDaoTao>(entity =>
        {
            entity.HasKey(e => e.MaHeDaoTao).HasName("he_dao_tao_pkey");
        });

        modelBuilder.Entity<HoSo>(entity =>
        {
            entity.HasKey(e => e.MaHoSo).HasName("ho_so_pkey");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.HoSos).HasConstraintName("ho_so_fkey_ma_sinh_vien");
        });

        modelBuilder.Entity<HocKyNamHoc>(entity =>
        {
            entity.HasKey(e => e.MaHocKyNamHoc).HasName("hoc_ky_nam_hoc_pkey");
        });

        modelBuilder.Entity<HocPhan>(entity =>
        {
            entity.HasKey(e => e.MaHocPhan).HasName("hoc_phan_pkey");

            entity.HasOne(d => d.MaGiangVienNavigation).WithMany(p => p.HocPhans).HasConstraintName("hoc_phan_fkey_ma_giang_vien");

            entity.HasOne(d => d.MaHeDaoTaoNavigation).WithMany(p => p.HocPhans).HasConstraintName("hoc_phan_fkey_ma_he_dao_tao");

            entity.HasOne(d => d.MaHocKyNamHocNavigation).WithMany(p => p.HocPhans).HasConstraintName("hoc_phan_fkey_ma_hoc_ky_nam_hoc");

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.HocPhans).HasConstraintName("hoc_phan_fkey_ma_mon_hoc");
        });

        modelBuilder.Entity<KetQuaHocTap>(entity =>
        {
            entity.HasKey(e => e.MaKetQuaHocTap).HasName("ket_qua_hoc_tap_pkey");

            entity.HasOne(d => d.MaHocKyNamHocNavigation).WithMany(p => p.KetQuaHocTaps).HasConstraintName("ket_qua_hoc_tap_fkey_ma_hoc_ky_nam_hoc");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.KetQuaHocTaps).HasConstraintName("ket_qua_hoc_tap_fkey_ma_sinh_vien");
        });

        modelBuilder.Entity<KetQuaRenLuyen>(entity =>
        {
            entity.HasKey(e => e.MaKetQuaRenLuyen).HasName("ket_qua_ren_luyen_pkey");

            entity.HasOne(d => d.MaHocKyNamHocNavigation).WithMany(p => p.KetQuaRenLuyens).HasConstraintName("ket_qua_ren_luyen_fkey_ma_hoc_ky_nam_hoc");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.KetQuaRenLuyens).HasConstraintName("ket_qua_ren_luyen_fkey_ma_sinh_vien");
        });

        modelBuilder.Entity<KhenThuong>(entity =>
        {
            entity.HasKey(e => e.MaKhenThuong).HasName("khen_thuong_pkey");

            entity.HasOne(d => d.MaHocKyNamHocNavigation).WithMany(p => p.KhenThuongs).HasConstraintName("khen_thuong_fkey_ma_hoc_ky_nam_hoc");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.KhenThuongs).HasConstraintName("khen_thuong_fkey_ma_sinh_vien");
        });

        modelBuilder.Entity<KhoaDaoTao>(entity =>
        {
            entity.HasKey(e => e.MaKhoaDaoTao).HasName("khoa_dao_tao_pkey");
        });

        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.HasKey(e => e.MaKhoaHoc).HasName("khoa_hoc_pkey");

            entity.HasOne(d => d.MaCoVanHocTapNavigation).WithMany(p => p.KhoaHocs).HasConstraintName("khoa_hoc_fkey_ma_co_van_hoc_tap");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMonHoc).HasName("mon_hoc_pkey");
        });

        modelBuilder.Entity<MonHocThuocBoMon>(entity =>
        {
            entity.HasKey(e => e.MaMonHoc).HasName("mon_hoc_thuoc_bo_mon_pkey");

            entity.Property(e => e.MaMonHoc).ValueGeneratedNever();

            entity.HasOne(d => d.MaBoMonNavigation).WithMany(p => p.MonHocThuocBoMons).HasConstraintName("mon_hoc_thuoc_bo_mon_fkey_ma_bo_mon");

            entity.HasOne(d => d.MaMonHocNavigation).WithOne(p => p.MonHocThuocBoMon).HasConstraintName("mon_hoc_thuoc_bo_mon_fkey_ma_mon_hoc");
        });

        modelBuilder.Entity<MonHocThuocKhoaDaoTao>(entity =>
        {
            entity.HasKey(e => e.MaMonHoc).HasName("mon_hoc_thuoc_khoa_dao_tao_pkey");

            entity.Property(e => e.MaMonHoc).ValueGeneratedNever();

            entity.HasOne(d => d.MaKhoaDaoTaoNavigation).WithMany(p => p.MonHocThuocKhoaDaoTaos).HasConstraintName("mon_hoc_thuoc_khoa_dao_tao_fkey_ma_khoa_dao_tao");

            entity.HasOne(d => d.MaMonHocNavigation).WithOne(p => p.MonHocThuocKhoaDaoTao).HasConstraintName("mon_hoc_thuoc_khoa_dao_tao_fkey_ma_mon_hoc");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("sinh_vien_pkey");

            entity.HasOne(d => d.MaChuyenNganhNavigation).WithMany(p => p.SinhViens).HasConstraintName("sinh_vien_fkey_ma_chuyen_nganh");

            entity.HasOne(d => d.MaHeDaoTaoNavigation).WithMany(p => p.SinhViens).HasConstraintName("sinh_vien_fkey_ma_he_dao_tao");

            entity.HasOne(d => d.MaKhoaHocNavigation).WithMany(p => p.SinhViens).HasConstraintName("sinh_vien_fkey_ma_khoa_hoc");
        });

        modelBuilder.Entity<ThongTinDangKyHocPhan>(entity =>
        {
            entity.HasKey(e => e.MaThongTinDangKyHocPhan).HasName("thong_tin_dang_ky_hoc_phan_pkey");
        });

        modelBuilder.Entity<ThongTinHocKyNamHoc>(entity =>
        {
            entity.HasKey(e => e.MaThongTinHocKyNamHoc).HasName("thong_tin_hoc_ky_nam_hoc_pkey");

            entity.HasOne(d => d.MaHocKyNamHocNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_hoc_ky_nam_hoc");

            entity.HasOne(d => d.MaKetQuaHocTapNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_ket_qua_hoc_tap");

            entity.HasOne(d => d.MaKetQuaRenLuyenNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_ket_qua_ren_luyen");

            entity.HasOne(d => d.MaKhenThuongNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_khen_thuong");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_sinh_vien");

            entity.HasOne(d => d.MaThongTinDangKyHocPhanNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_thong_tin_dang_ky_hoc_phan");

            entity.HasOne(d => d.MaThongTinHocKyNamHocTruocNavigation).WithMany(p => p.InverseMaThongTinHocKyNamHocTruocNavigation)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_thong_tin_hoc_ky_nam_hoc_truoc");

            entity.HasOne(d => d.MaThongTinHocPhiNavigation).WithMany(p => p.ThongTinHocKyNamHocs).HasConstraintName("thong_tin_hoc_ky_nam_hoc_fkey_ma_thong_tin_hoc_phi");
        });

        modelBuilder.Entity<ThongTinHocPhi>(entity =>
        {
            entity.HasKey(e => e.MaThongTinHocPhi).HasName("thong_tin_hoc_phi_pkey");

            entity.HasOne(d => d.MaHocKyNamHocNavigation).WithMany(p => p.ThongTinHocPhis).HasConstraintName("thong_tin_hoc_phi_fkey_ma_hoc_ky_nam_hoc");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.ThongTinHocPhis).HasConstraintName("thong_tin_hoc_phi_fkey_ma_sinh_vien");

            entity.HasOne(d => d.MaThongTinHocPhiNavigation).WithOne(p => p.InverseMaThongTinHocPhiNavigation).HasConstraintName("thong_tin_hoc_phi_fkey_ma_thong_tin_hoc_phi_hoc_ky_truoc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
