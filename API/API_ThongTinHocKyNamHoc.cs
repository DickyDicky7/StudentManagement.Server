namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocKyNamHoc
    {
        public static WebApplication MapAPI_ThongTinHocKyNamHoc(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-hoc-ky-nam-hoc/get-many", InternalMethods.ThongTinHocKyNamHoc_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/thong-tin-hoc-ky-nam-hoc/add-many", InternalMethods.ThongTinHocKyNamHoc_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinHocKyNamHoc reqBodyFilter)
            {
                ResBody_GetMany<ThongTinHocKyNamHoc> resBody_GetMany = new()
                {
                    Result = await context.ThongTinHocKyNamHocs
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<ThongTinHocKyNamHoc>> ThongTinHocKyNamHoc_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ThongTinHocKyNamHoc, ThongTinHocKyNamHoc> reqBody_AddMany)
            {
                ResBody_AddMany<ThongTinHocKyNamHoc> resBody_AddMany      = new();
                IEnumerable    <ThongTinHocKyNamHoc> thongTinHocKyNamHocs = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
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

        }
    }
}
