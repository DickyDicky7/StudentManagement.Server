namespace StudentManagement.Server.API
{
    public static class API_GiangVienThuocBoMon
    {
        public static WebApplication MapAPI_GiangVienThuocBoMon(this WebApplication app)
        {
            app
                .MapPost (@"/giang-vien-thuoc-bo-mon/get-many", InternalMethods.GiangVienThuocBoMon_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/giang-vien-thuoc-bo-mon/add-many", InternalMethods.GiangVienThuocBoMon_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/giang-vien-thuoc-bo-mon/update-many", InternalMethods.GiangVienThuocBoMon_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/giang-vien-thuoc-bo-mon/remove-many", InternalMethods.GiangVienThuocBoMon_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVienThuocBoMon>> GiangVienThuocBoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_GiangVienThuocBoMon,  GiangVienThuocBoMon> reqBody_GetMany)
            {
                ResBody_GetMany<GiangVienThuocBoMon> resBody_GetMany = new()
                {
                    Result = await context.GiangVienThuocBoMons
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           GiangVienThuocBoMon>> GiangVienThuocBoMon_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_GiangVienThuocBoMon,  GiangVienThuocBoMon> reqBody_AddMany)
            {
                ResBody_AddMany<GiangVienThuocBoMon> resBody_AddMany      = new();
                List           <GiangVienThuocBoMon> giangVienThuocBoMons = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()) .ToList();
                await   context.GiangVienThuocBoMons.AddRangeAsync(giangVienThuocBoMons);
                resBody_AddMany.NumberOfRowsAffected  = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = giangVienThuocBoMons
                    .Where (giangVienThuocBoMon  => giangVienThuocBoMon.MaGiangVien != default)
                    .Select(giangVienThuocBoMon  => giangVienThuocBoMon.MaGiangVien);
                }
                else
                {
                    resBody_AddMany.Result        = giangVienThuocBoMons
                    .Where (giangVienThuocBoMon  => giangVienThuocBoMon.MaGiangVien != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<GiangVienThuocBoMon>> GiangVienThuocBoMon_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_GiangVienThuocBoMon,  GiangVienThuocBoMon> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<GiangVienThuocBoMon> resBody_UpdateMany = new();
                resBody_UpdateMany.NumberOfRowsAffected = await context.GiangVienThuocBoMons.Where(
                reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModel());
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long               >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<GiangVienThuocBoMon>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<GiangVienThuocBoMon>> GiangVienThuocBoMon_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_GiangVienThuocBoMon,  GiangVienThuocBoMon> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<GiangVienThuocBoMon> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds = new List<long               >();
                }
                else
                {
                    resBody_RemoveMany.Result        = new List<GiangVienThuocBoMon>();
                }
                resBody_RemoveMany.NumberOfRowsAffected = await context.GiangVienThuocBoMons.Where(
                reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
