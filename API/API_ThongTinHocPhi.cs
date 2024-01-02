namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocPhi
    {
        public static WebApplication MapAPI_ThongTinHocPhi(this WebApplication app)
        {
            app
                .MapPost(@"/thong-tin-hoc-phi/get-many", InternalMethods.ThongTinHocPhi_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/thong-tin-hoc-phi/add-many", InternalMethods.ThongTinHocPhi_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinHocPhi>> ThongTinHocPhi_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ThongTinHocPhi reqBodyFilter)
            {
                ResBody_GetMany<ThongTinHocPhi> resBody_GetMany = new()
                {
                    Result = await context.ThongTinHocPhis
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<ThongTinHocPhi>> ThongTinHocPhi_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ThongTinHocPhi, ThongTinHocPhi> reqBody_AddMany)
            {
                ResBody_AddMany<ThongTinHocPhi> resBody_AddMany = new();
                IEnumerable    <ThongTinHocPhi> thongTinHocPhis = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.ThongTinHocPhis.AddRangeAsync(thongTinHocPhis);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = thongTinHocPhis
                        .Where (thongTinHocPhi => thongTinHocPhi.MaThongTinHocPhi != default)
                        .Select(thongTinHocPhi => thongTinHocPhi.MaThongTinHocPhi);
                }
                else
                {
                    resBody_AddMany.Result        = thongTinHocPhis
                        .Where (thongTinHocPhi => thongTinHocPhi.MaThongTinHocPhi != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
