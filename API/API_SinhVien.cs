namespace StudentManagement.Server.API
{
    public static class API_SinhVien
    {
        public static WebApplication MapAPI_SinhVien(this WebApplication app)
        {
            app
                .MapPost (@"/sinh-vien/get-many", InternalMethods.SinhVien_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/sinh-vien/add-many", InternalMethods.SinhVien_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/sinh-vien/update-many", InternalMethods.SinhVien_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/sinh-vien/remove-many", InternalMethods.SinhVien_RemoveMany)
                .WithTags (@"Remove many");

            app
                .MapGet  (@"/sinh-vien/get-danh-sach-loai-tinh-trang-hoc-tap", InternalMethods.SinhVien_GetDanhSachLoaiTinhTrangHocTap)
                .WithTags(@"Danh sách loại tình trạng học tập");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<SinhVien>> SinhVien_GetMany(
                [FromServices] ApplicationDbContext   context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_SinhVien,  SinhVien> reqBody_GetMany)
            {
                ResBody_GetMany<SinhVien> resBody_GetMany = new()
                {
                    Result =(await context.SinhViens
                    .Include(row => row.ChuyenNganh)
                    .Include(row => row.   HeDaoTao)
                    .Include(row => row.   KhoaHoc)
                    .OrderBy(row => row.MaSinhVien)
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync()).Select(row =>
                    {
                        row.ChuyenNganh.SinhViens = null!;
                        row.   HeDaoTao.SinhViens = null!;
                        row.KhoaHoc    .SinhViens = null!;
                        return row;
                    }),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           SinhVien>> SinhVien_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_SinhVien,  SinhVien> reqBody_AddMany)
            {
                ResBody_AddMany<SinhVien> resBody_AddMany = new();
                List           <SinhVien> sinhViens       = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
                await   context.SinhViens.AddRangeAsync(sinhViens);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = sinhViens
                        .Where (sinhVien => sinhVien.MaSinhVien != default)
                        .Select(sinhVien => sinhVien.MaSinhVien);
                }
                else
                {
                    resBody_AddMany.Result        = sinhViens
                        .Where (sinhVien => sinhVien.MaSinhVien != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<SinhVien>> SinhVien_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_SinhVien,  SinhVien> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<SinhVien> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.SinhViens.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long    >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<SinhVien>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<SinhVien>> SinhVien_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_SinhVien,  SinhVien> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<SinhVien> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long    >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<SinhVien>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.SinhViens.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

            public static async Task<IResult> SinhVien_GetDanhSachLoaiTinhTrangHocTap(
                )
            {
                await
                Task.CompletedTask;
                return Results.Ok(new ResBody_Helper<List<string>>()
                {
                    Result = SinhVien.LoaiTinhTrangHocTaps,
                });
            }
        }
    }
}
