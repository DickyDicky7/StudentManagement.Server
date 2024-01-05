namespace StudentManagement.Server.Database
{
    public partial class ThongTinHocPhi : IModel<ThongTinHocPhi>
    {
        public void DongHocPhi(decimal soTien)
        {
            this.SoTienDaDong += soTien;
            this.SoTienPhaiDong = this.SoTienHocPhiTheoQuyDinh - this.SoTienDaDong;
            if (this.ThongTinHocPhiHocKyTruoc != null)
                this.SoTienPhaiDong -= ThongTinHocPhiHocKyTruoc.SoTienDu;
            this.SoTienDu = 0.0m;
            if (this.SoTienPhaiDong < 0.0m)
                this.SoTienDu = Math.Abs(this.SoTienPhaiDong);
            if (this.SoTienPhaiDong < 0.0m)
                this.SoTienPhaiDong = 0.0m;
        }


    }
}
