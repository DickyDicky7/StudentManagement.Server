namespace StudentManagement.Server.Bodies.Req.Specific
{
    public record class ReqBody_BangDiemHocPhan : BaseReqBody<BangDiemHocPhan>
    {
        public long   ? MaBangDiemHocPhan { get; set; }
        public long   ? MaHocPhan         { get; set; }
        public long   ? MaSinhVien        { get; set; }
        public decimal? DiemQuaTrinh      { get; set; }
        public decimal? DiemGiuaKy        { get; set; }
        public decimal? DiemThucHanh      { get; set; }
        public decimal? DiemCuoiKy        { get; set; }
        public decimal? DiemTong          { get; set; }

        public override Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BangDiemHocPhan>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BangDiemHocPhan>>> UpdateModel()
        {
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BangDiemHocPhan>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<BangDiemHocPhan>>> chain = setter => setter;

            if (this.MaBangDiemHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaBangDiemHocPhan,
                        this  .MaBangDiemHocPhan));

            if (this.MaHocPhan != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaHocPhan,
                        this  .MaHocPhan));

            if (this.MaSinhVien != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.MaSinhVien,
                        this  .MaSinhVien));

            if (this.DiemQuaTrinh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DiemQuaTrinh,
                        this  .DiemQuaTrinh));

            if (this.DiemGiuaKy != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DiemGiuaKy,
                        this  .DiemGiuaKy));

            if (this.DiemThucHanh != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DiemThucHanh,
                        this  .DiemThucHanh));

            if (this.DiemCuoiKy != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DiemCuoiKy,
                        this  .DiemCuoiKy));

            if (this.DiemTong != null)
                chain = Helper.AppendSetterProperty(chain,
                    setter =>
                    setter.SetProperty(
                        entity =>
                        entity.DiemTong,
                        this  .DiemTong));

            return chain;
        }

        public override Expression<Func<BangDiemHocPhan, bool>> MatchExpression()
        {
            return (model) =>
            (MaBangDiemHocPhan == null ||
             MaBangDiemHocPhan == model.MaBangDiemHocPhan) &&
            (MaHocPhan         == null ||
             MaHocPhan         == model.MaHocPhan)         &&
            (MaSinhVien        == null ||
             MaSinhVien        == model.MaSinhVien)        &&
            (DiemQuaTrinh      == null ||
             DiemQuaTrinh      == model.DiemQuaTrinh)      &&
            (DiemGiuaKy        == null ||
             DiemGiuaKy        == model.DiemGiuaKy)        &&
            (DiemThucHanh      == null ||
             DiemThucHanh      == model.DiemThucHanh)      &&
            (DiemCuoiKy        == null ||
             DiemCuoiKy        == model.DiemCuoiKy)        &&
            (DiemTong          == null ||
             DiemTong          == model.DiemTong);
        }
    }

    public record class JustForInsertReqBody_BangDiemHocPhan : ReqBody_BangDiemHocPhan
    {
        [SwaggerSchema(ReadOnly = true)]
        public new long   ? MaBangDiemHocPhan { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public new decimal? DiemTong          { get; set; }
    }
}
