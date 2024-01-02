namespace StudentManagement.Server.API
{
    public static class API_KhenThuong
    {
        public static WebApplication MapAPI_KhenThuong(this WebApplication app)
        {
            app
                .MapPost(@"/khen-thuong/get-many", InternalMethods.KhenThuong_GetMany)
                .WithTags(@"Get many, execution order: [filter] where -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/khen-thuong/add-many", InternalMethods.KhenThuong_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<KhenThuong>> KhenThuong_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_KhenThuong reqBodyFilter)
            {
                ResBody_GetMany<KhenThuong> resBody_GetMany = new()
                {
                    Result = await context.KhenThuongs
                    .Where(reqBodyFilter
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<KhenThuong>> KhenThuong_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_KhenThuong, KhenThuong> reqBody_AddMany)
            {
                ResBody_AddMany<KhenThuong> resBody_AddMany = new() ;
                IEnumerable    <KhenThuong> khenThuongs     = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.KhenThuongs.AddRangeAsync(khenThuongs);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = khenThuongs
                    .Where (khenThuong => khenThuong.MaKhenThuong != default)
                    .Select(khenThuong => khenThuong.MaKhenThuong);
                }
                else
                {
                    resBody_AddMany.Result        = khenThuongs
                    .Where (khenThuong => khenThuong.MaKhenThuong != default);
                }
                return resBody_AddMany;
            }
        }
    }
}
