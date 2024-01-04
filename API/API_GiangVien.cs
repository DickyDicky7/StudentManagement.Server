namespace StudentManagement.Server.API
{
    public static class API_GiangVien
    {
        public static WebApplication MapAPI_GiangVien(this WebApplication app)
        {
            app
                .MapPost (@"/giang-vien/get-many", InternalMethods.GiangVien_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/giang-vien/add-many", InternalMethods.GiangVien_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/giang-vien/update-many", InternalMethods.GiangVien_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/giang-vien/remove-many", InternalMethods.GiangVien_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVien>> GiangVien_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_GiangVien,  GiangVien> reqBody_GetMany)
            {
                ResBody_GetMany<GiangVien> resBody_GetMany = new()
                {
                    Result = await context.GiangViens
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           GiangVien>> GiangVien_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_GiangVien,  GiangVien> reqBody_AddMany)
            {
                ResBody_AddMany<GiangVien> resBody_AddMany = new();
                IEnumerable    <GiangVien> giangViens      = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel());
                await   context.GiangViens.AddRangeAsync(giangViens);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = giangViens
                        .Where (giangVien => giangVien.MaGiangVien != default)
                        .Select(giangVien => giangVien.MaGiangVien);
                }
                else
                {
                    resBody_AddMany.Result        = giangViens
                        .Where (giangVien => giangVien.MaGiangVien != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<GiangVien>> GiangVien_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_GiangVien,  GiangVien> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<GiangVien> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.GiangViens.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long     >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<GiangVien>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<GiangVien>> GiangVien_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_GiangVien,  GiangVien> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<GiangVien> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long     >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<GiangVien>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.GiangViens.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
