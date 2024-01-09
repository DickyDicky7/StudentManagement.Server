namespace StudentManagement.Server.API
{
    public static class API_BangDiemHocPhan
    {
        public static WebApplication MapAPI_BangDiemHocPhan(this WebApplication app)
        {
            app
                .MapPost (@"/bang-diem-hoc-phan/get-many", InternalMethods.BangDiemHocPhan_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/bang-diem-hoc-phan/add-many", InternalMethods.BangDiemHocPhan_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/bang-diem-hoc-phan/update-many", InternalMethods.BangDiemHocPhan_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/bang-diem-hoc-phan/remove-many", InternalMethods.BangDiemHocPhan_RemoveMany)
                .WithTags (@"Remove many");

            app
                .MapGet  (@"/bang-diem-hoc-phan/get-tinh-tong-diem", InternalMethods.BangDiemHocPhan_GetTinhTongDiem)
                .WithTags(@"Tính tổng điểm cho bảng điểm học phần");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<BangDiemHocPhan>> BangDiemHocPhan_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_GetMany)
            {
                ResBody_GetMany<BangDiemHocPhan> resBody_GetMany = new()
                {
                    Result = (
                    await context.BangDiemHocPhans
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .Include(row =>    row.SinhVien         )
                    .OrderBy(row =>    row.MaBangDiemHocPhan)
                    .ToListAsync()
                    ).Select(row =>
                    {
                        row.SinhVien.BangDiemHocPhans = null!;
                        return row;
                    }),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           BangDiemHocPhan>> BangDiemHocPhan_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_AddMany)
            {
                ResBody_AddMany<BangDiemHocPhan> resBody_AddMany  = new();
                List           <BangDiemHocPhan> bangDiemHocPhans = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
                bangDiemHocPhans
                .ForEach(bangDiemHocPhan =>
                {
                bangDiemHocPhan.TinhDiemTong();
                });
                await   context.BangDiemHocPhans.AddRangeAsync(bangDiemHocPhans);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = bangDiemHocPhans
                        .Where (bangDiemHocPhan => bangDiemHocPhan.MaBangDiemHocPhan != default)
                        .Select(bangDiemHocPhan => bangDiemHocPhan.MaBangDiemHocPhan);
                }
                else
                {
                    resBody_AddMany.Result        = bangDiemHocPhans
                        .Where (bangDiemHocPhan => bangDiemHocPhan.MaBangDiemHocPhan != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<BangDiemHocPhan>> BangDiemHocPhan_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<BangDiemHocPhan> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.BangDiemHocPhans.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModelExpression());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long           >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<BangDiemHocPhan>();
                }
                List<BangDiemHocPhan> bangDiemHocPhans
                = await context.BangDiemHocPhans.Where(reqBody_UpdateMany.FilterBy.MatchExpression()).ToListAsync();
                bangDiemHocPhans
                .ForEach(bangDiemHocPhan =>
                {
                bangDiemHocPhan.TinhDiemTong();
                context.BangDiemHocPhans.Where( row => row.MaBangDiemHocPhan == bangDiemHocPhan.MaBangDiemHocPhan)
                .ExecuteUpdate(setter => setter.SetProperty(row => row.DiemTong,bangDiemHocPhan.DiemTong));
                });
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<BangDiemHocPhan>> BangDiemHocPhan_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_BangDiemHocPhan,  BangDiemHocPhan> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<BangDiemHocPhan> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long           >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<BangDiemHocPhan>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.BangDiemHocPhans.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

            public static async Task<IResult> BangDiemHocPhan_GetTinhTongDiem(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "ma-bang-diem-hoc-phan")] long   maBangDiemHocPhan)
            {
                BangDiemHocPhan bangDiemHocPhan = (await context.BangDiemHocPhans.FindAsync(maBangDiemHocPhan))!;
                if (bangDiemHocPhan != null)
                {
                    return Results.Ok      (new ResBody_Helper<object>()
                    {
                        Result = bangDiemHocPhan.TinhTongDiem(),
                    });
                }
                else
                {
                    return Results.NotFound(new ResBody_Helper<string>()
                    {
                        Result = "invalid ma-bang-diem-hoc-phan: ma-bang-diem-hoc-phan not found",
                    });
                }
            }
        }
    }
}
