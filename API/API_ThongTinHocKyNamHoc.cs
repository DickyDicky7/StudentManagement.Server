namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocKyNamHoc
    {
        public static WebApplication MapAPI_ThongTinHocKyNamHoc(this WebApplication app)
        {
            app
                .MapPost (@"/thong-tin-hoc-ky-nam-hoc/get-many", InternalMethods.ThongTinHocKyNamHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/thong-tin-hoc-ky-nam-hoc/add-many", InternalMethods.ThongTinHocKyNamHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/thong-tin-hoc-ky-nam-hoc/update-many", InternalMethods.ThongTinHocKyNamHoc_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/thong-tin-hoc-ky-nam-hoc/remove-many", InternalMethods.ThongTinHocKyNamHoc_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_ThongTinHocKyNamHoc,  ThongTinHocKyNamHoc> reqBody_GetMany)
            {
                ResBody_GetMany<ThongTinHocKyNamHoc> resBody_GetMany = new()
                {
                    Result = await context.ThongTinHocKyNamHocs
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ThongTinHocKyNamHoc,  ThongTinHocKyNamHoc> reqBody_AddMany)
            {
                ResBody_AddMany<ThongTinHocKyNamHoc> resBody_AddMany      = new();
                List           <ThongTinHocKyNamHoc> thongTinHocKyNamHocs = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
                await   context.ThongTinHocKyNamHocs.AddRangeAsync(thongTinHocKyNamHocs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = thongTinHocKyNamHocs
                        .Where (thongTinHocKyNamHoc => thongTinHocKyNamHoc.MaThongTinHocKyNamHoc != default)
                        .Select(thongTinHocKyNamHoc => thongTinHocKyNamHoc.MaThongTinHocKyNamHoc);
                }
                else
                {
                    resBody_AddMany.Result        = thongTinHocKyNamHocs
                        .Where (thongTinHocKyNamHoc => thongTinHocKyNamHoc.MaThongTinHocKyNamHoc != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_ThongTinHocKyNamHoc,  ThongTinHocKyNamHoc> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<ThongTinHocKyNamHoc> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.ThongTinHocKyNamHocs.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long               >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<ThongTinHocKyNamHoc>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_ThongTinHocKyNamHoc,  ThongTinHocKyNamHoc> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<ThongTinHocKyNamHoc> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long               >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<ThongTinHocKyNamHoc>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.ThongTinHocKyNamHocs.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
