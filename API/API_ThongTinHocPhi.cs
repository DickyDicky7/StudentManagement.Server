namespace StudentManagement.Server.API
{
    public static class API_ThongTinHocPhi
    {
        public static WebApplication MapAPI_ThongTinHocPhi(this WebApplication app)
        {
            app
                .MapPost (@"/thong-tin-hoc-phi/get-many", InternalMethods.ThongTinHocPhi_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/thong-tin-hoc-phi/add-many", InternalMethods.ThongTinHocPhi_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/thong-tin-hoc-phi/update-many", InternalMethods.ThongTinHocPhi_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/thong-tin-hoc-phi/remove-many", InternalMethods.ThongTinHocPhi_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<ThongTinHocPhi>> ThongTinHocPhi_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_ThongTinHocPhi,  ThongTinHocPhi> reqBody_GetMany)
            {
                ResBody_GetMany<ThongTinHocPhi> resBody_GetMany = new()
                {
                    Result = await context.ThongTinHocPhis
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           ThongTinHocPhi>> ThongTinHocPhi_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_ThongTinHocPhi,  ThongTinHocPhi> reqBody_AddMany)
            {
                ResBody_AddMany<ThongTinHocPhi> resBody_AddMany = new();
                List           <ThongTinHocPhi> thongTinHocPhis = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList ();
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

            public static async Task<ResBody_UpdateMany<ThongTinHocPhi>> ThongTinHocPhi_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_ThongTinHocPhi,  ThongTinHocPhi> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<ThongTinHocPhi> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.ThongTinHocPhis.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long          >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<ThongTinHocPhi>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<ThongTinHocPhi>> ThongTinHocPhi_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_ThongTinHocPhi,  ThongTinHocPhi> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<ThongTinHocPhi> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long          >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<ThongTinHocPhi>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.ThongTinHocPhis.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
