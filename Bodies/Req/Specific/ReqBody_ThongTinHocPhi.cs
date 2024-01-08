namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_ThongTinHocPhi : BaseReqBody<ThongTinHocPhi>
    {
        public long          ? MaThongTinHocPhi           { get; set; }
        public decimal       ? SoTienHocPhiTheoQuyDinh    { get; set; }
        public decimal       ? SoTienPhaiDong             { get; set; }
        public decimal       ? SoTienDaDong               { get; set; }
        public decimal       ? SoTienDu                   { get; set; }
        public string        ? TenNganHangThanhToanHocPhi { get; set; }
        public DateTimeOffset? ThoiDiemThanhToanHocPhi    { get; set; }
        public string        ? GhiChuBoSung               { get; set; }
        public long          ? MaThongTinHocPhiHocKyTruoc { get; set; }
        public long          ? MaHocKyNamHoc              { get; set; }
        public long          ? MaSinhVien                 { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocPhi>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocPhi>>> UpdateModelExpression()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocPhi>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<ThongTinHocPhi>>> chain = setter => setter;

            if (this.MaThongTinHocPhi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinHocPhi,
                        this  .MaThongTinHocPhi));

            if (this.SoTienHocPhiTheoQuyDinh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTienHocPhiTheoQuyDinh,
                        this  .SoTienHocPhiTheoQuyDinh));

            if (this.SoTienPhaiDong != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTienPhaiDong,
                        this  .SoTienPhaiDong));

            if (this.SoTienDaDong != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTienDaDong,
                        this  .SoTienDaDong));

            if (this.SoTienDu != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.SoTienDu,
                        this  .SoTienDu));

            if (this.TenNganHangThanhToanHocPhi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.TenNganHangThanhToanHocPhi,
                        this  .TenNganHangThanhToanHocPhi));

            if (this.ThoiDiemThanhToanHocPhi != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.ThoiDiemThanhToanHocPhi,
                        this  .ThoiDiemThanhToanHocPhi));

            if (this.GhiChuBoSung != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.GhiChuBoSung,
                        this  .GhiChuBoSung));

            if (this.MaThongTinHocPhiHocKyTruoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinHocPhiHocKyTruoc,
                        this  .MaThongTinHocPhiHocKyTruoc));

            if (this.MaHocKyNamHoc != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocKyNamHoc,
                        this  .MaHocKyNamHoc));

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            return chain;
        }

        public override Expression<Func<ThongTinHocPhi, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinHocPhi           == null ||
             MaThongTinHocPhi           == model.MaThongTinHocPhi)           &&
            (SoTienHocPhiTheoQuyDinh    == null ||
             SoTienHocPhiTheoQuyDinh    == model.SoTienHocPhiTheoQuyDinh)    &&
            (SoTienPhaiDong             == null ||
             SoTienPhaiDong             == model.SoTienPhaiDong)             &&
            (SoTienDaDong               == null ||
             SoTienDaDong               == model.SoTienDaDong)               &&
            (SoTienDu                   == null ||
             SoTienDu                   == model.SoTienDu)                   &&
            (TenNganHangThanhToanHocPhi == null ||
             TenNganHangThanhToanHocPhi == model.TenNganHangThanhToanHocPhi) &&
            (ThoiDiemThanhToanHocPhi    == null ||
             ThoiDiemThanhToanHocPhi    == model.ThoiDiemThanhToanHocPhi)    &&
            (GhiChuBoSung               == null ||
             GhiChuBoSung               == model.GhiChuBoSung)               &&
            (MaThongTinHocPhiHocKyTruoc == null ||
             MaThongTinHocPhiHocKyTruoc == model.MaThongTinHocPhiHocKyTruoc) &&
            (MaHocKyNamHoc              == null ||
             MaHocKyNamHoc              == model.MaHocKyNamHoc)              &&
            (MaSinhVien                 == null ||
             MaSinhVien                 == model.MaSinhVien);
        }
    }

    public record class JustForInsertReqBody_ThongTinHocPhi : ReqBody_ThongTinHocPhi
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long? MaThongTinHocPhi { get; set; }
    }
}
