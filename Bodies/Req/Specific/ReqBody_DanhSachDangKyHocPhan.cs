namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_DanhSachDangKyHocPhan : BaseReqBody<DanhSachDangKyHocPhan>
    {
        public long? MaThongTinDangKyHocPhan { get; set; }
        public long? MaHocPhan               { get; set; }
        public bool? HocLaiHayHocCaiThien    { get; set; }
        public long? MaBangDiemHocPhan       { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<DanhSachDangKyHocPhan>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<DanhSachDangKyHocPhan>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<DanhSachDangKyHocPhan>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<DanhSachDangKyHocPhan>>> chain = setter => setter;

            if (this.MaThongTinDangKyHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaThongTinDangKyHocPhan,
                        this  .MaThongTinDangKyHocPhan));

            if (this.MaHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocPhan,
                        this  .MaHocPhan));

            if (this.HocLaiHayHocCaiThien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.HocLaiHayHocCaiThien,
                        this  .HocLaiHayHocCaiThien));

            if (this.MaBangDiemHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaBangDiemHocPhan,
                        this  .MaBangDiemHocPhan));

            return chain;
        }

        public override Expression<Func<DanhSachDangKyHocPhan, bool>> MatchExpression()
        {
            return (model) =>
            (MaThongTinDangKyHocPhan == null ||
             MaThongTinDangKyHocPhan == model.MaThongTinDangKyHocPhan) &&
            (MaHocPhan               == null ||
             MaHocPhan               == model.MaHocPhan)               &&
            (HocLaiHayHocCaiThien    == null ||
             HocLaiHayHocCaiThien    == model.HocLaiHayHocCaiThien)    &&
            (MaBangDiemHocPhan       == null ||
             MaBangDiemHocPhan       == model.MaBangDiemHocPhan);
        }
    }

    public record class JustForInsertReqBody_DanhSachDangKyHocPhan : ReqBody_DanhSachDangKyHocPhan
    {

    }
}
