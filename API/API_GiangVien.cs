namespace StudentManagement.Server.API
{
    public static class API_GiangVien
    {
        public static WebApplication MapAPI_GiangVien(this WebApplication app)
        {
            app
                .MapPost(@"/giang-vien/get-many", InternalMethods.GiangVien_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost(@"/giang-vien/add-many", InternalMethods.GiangVien_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapDelete(@"/giang-vien/remove-many", InternalMethods.GiangVien_RemoveMany)
                .WithTags(@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVien>> GiangVien_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<ReqBody_GiangVien, GiangVien> reqBody_GetMany)
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

            public static async Task<ResBody_AddMany<GiangVien>> GiangVien_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_GiangVien, GiangVien> reqBody_AddMany)
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

            public static async Task<ResBody_RemoveMany<GiangVien>> GiangVien_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<ReqBody_GiangVien, GiangVien> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<GiangVien> resBody_RemoveMany = new();
                IQueryable        <GiangVien> giangViens         = context.GiangViens.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression());
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = giangViens
                    .Select(giangVien => giangVien.MaGiangVien);
                }
                else
                {
                    resBody_RemoveMany.Result        = giangViens;
                }
                context.GiangViens
                       .RemoveRange(giangViens);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
