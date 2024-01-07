namespace StudentManagement.Server.Database
{
    public partial class BangDiemHocPhan : IModel<BangDiemHocPhan>
    {
        public decimal TinhTongDiem()
        {
            if (this.HocPhan != null)
            {
                if (this.HocPhan.HinhThucThi == "bài kiểm tra lý thuyết cuối kỳ")
                {
                    return 0.25m * this.DiemQuaTrinh
                        +  0.25m * this.DiemGiuaKy
                        +  0.50m * this.DiemCuoiKy;
                }
                if (this.HocPhan.HinhThucThi == "bài kiểm tra thực hành cuối kỳ")
                {
                    return 1.00m * this.DiemThucHanh;
                }
                return 0.0m;
            }
            else
            {
                return 0.0m;
            }
        }

    }
}
