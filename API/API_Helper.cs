namespace StudentManagement.Server.API
{
    public static class API_Helper
    {
        public static WebApplication MapAPI_Helper(this WebApplication app)
        {
            app
                .MapGet(@"/tinh-trang-hoc-tap/get-all", () =>
                {
                    return new ResBody_Helper<List<string>>()
                    {
                        Result = SinhVien.LoaiTinhTrangHocTap,
                    };
                })
                .WithTags(@"Helper");

            app
                .MapGet(@"/thang-diem-hoc-tap/get-all", () =>
                {
                    return new ResBody_Helper<List<Common.BacDiem>>()
                    {
                        Result = KetQuaHocTap.ThangDiemHocTap,
                    };
                })
                .WithTags(@"Helper");

            app
                .MapGet(@"/thang-diem-ren-luyen/get-all", () =>
                {
                    return new ResBody_Helper<List<Common.BacDiem>>()
                    {
                        Result = KetQuaRenLuyen.ThangDiemRenLuyen,
                    };
                })
                .WithTags(@"Helper");

            return app;
        }
    }
}
