namespace StudentManagement.Server.API
{
    public static class API_GiangVienThuocKhoaDaoTao
    {
        public static WebApplication MapAPI_GiangVienThuocKhoaDaoTao(this WebApplication app)
        {
            app
                .MapPost (@"/giang-vien-thuoc-khoa-dao-tao/get-many", InternalMethods.GiangVienThuocKhoaDaoTao_GetMany)
                .WithTags(@"Get many, execution order: [filter by matching] body -> [skip] offset -> [take] limit");

            app
                .MapPost (@"/giang-vien-thuoc-khoa-dao-tao/add-many", InternalMethods.GiangVienThuocKhoaDaoTao_AddMany)
                .WithTags(@"Add many, able to return just new records'id or new records | new records have id auto generated");

            app
                .MapPut   (@"/giang-vien-thuoc-khoa-dao-tao/update-many", InternalMethods.GiangVienThuocKhoaDaoTao_UpdateMany)
                .WithTags (@"Update many");

            app
                .MapDelete(@"/giang-vien-thuoc-khoa-dao-tao/remove-many", InternalMethods.GiangVienThuocKhoaDaoTao_RemoveMany)
                .WithTags (@"Remove many");

            return app;
        }

        private static class InternalMethods
        {
            public static async Task<ResBody_GetMany<GiangVienThuocKhoaDaoTao>> GiangVienThuocKhoaDaoTao_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_GetMany<  ReqBody_GiangVienThuocKhoaDaoTao,  GiangVienThuocKhoaDaoTao> reqBody_GetMany)
            {
                ResBody_GetMany<GiangVienThuocKhoaDaoTao> resBody_GetMany = new()
                {
                    Result = await context.GiangVienThuocKhoaDaoTaos
                    .Where(reqBody_GetMany.FilterBy
                    .MatchExpression())
                    .Skip(offset).Take(limit)
                    .ToListAsync(),
                };
                return resBody_GetMany;
            }

            public static async Task<ResBody_AddMany<           GiangVienThuocKhoaDaoTao>> GiangVienThuocKhoaDaoTao_AddMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_AddMany<JustForInsertReqBody_GiangVienThuocKhoaDaoTao,  GiangVienThuocKhoaDaoTao> reqBody_AddMany)
            {
                ResBody_AddMany<GiangVienThuocKhoaDaoTao> resBody_AddMany           = new();
                List           <GiangVienThuocKhoaDaoTao> giangVienThuocKhoaDaoTaos = reqBody_AddMany
                .ItemsToAdd.Select(itemToAdd => itemToAdd.ToModel()).ToList();
                await   context.GiangVienThuocKhoaDaoTaos.AddRangeAsync(giangVienThuocKhoaDaoTaos);
                resBody_AddMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_AddMany.ReturnJustIds)
                {
                    resBody_AddMany.ResultJustIds = giangVienThuocKhoaDaoTaos
                        .Where (giangVienThuocKhoaDaoTao => giangVienThuocKhoaDaoTao.MaGiangVien != default)
                        .Select(giangVienThuocKhoaDaoTao => giangVienThuocKhoaDaoTao.MaGiangVien);
                }
                else
                {
                    resBody_AddMany.Result        = giangVienThuocKhoaDaoTaos
                        .Where (giangVienThuocKhoaDaoTao => giangVienThuocKhoaDaoTao.MaGiangVien != default);
                }
                return resBody_AddMany;
            }

            public static async Task<ResBody_UpdateMany<GiangVienThuocKhoaDaoTao>> GiangVienThuocKhoaDaoTao_UpdateMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_UpdateMany<  ReqBody_GiangVienThuocKhoaDaoTao,  GiangVienThuocKhoaDaoTao> reqBody_UpdateMany)
            {
                ResBody_UpdateMany<GiangVienThuocKhoaDaoTao> resBody_UpdateMany = new();
                //resBody_UpdateMany.NumberOfRowsAffected = await context.GiangVienThuocKhoaDaoTaos.Where(
                //reqBody_UpdateMany.FilterBy.MatchExpression()).ExecuteUpdateAsync(reqBody_UpdateMany.UpdateTo.UpdateModelExpression());
                List      <GiangVienThuocKhoaDaoTao> query = await
                context   .GiangVienThuocKhoaDaoTaos
                .  Where(reqBody_UpdateMany.FilterBy.MatchExpression())
                .ToListAsync();
                query
                .ForEach(reqBody_UpdateMany.UpdateTo.UpdateModel);
                context   .GiangVienThuocKhoaDaoTaos
                .UpdateRange(query);
                resBody_UpdateMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                if (reqBody_UpdateMany.ReturnJustIds)
                {
                    resBody_UpdateMany.ResultJustIds = new List<long                    >();
                }
                else
                {
                    resBody_UpdateMany.Result        = new List<GiangVienThuocKhoaDaoTao>();
                }
                return resBody_UpdateMany;
            }

            public static async Task<ResBody_RemoveMany<GiangVienThuocKhoaDaoTao>> GiangVienThuocKhoaDaoTao_RemoveMany(
                [FromServices] ApplicationDbContext context,
                [FromBody] ReqBody_RemoveMany<  ReqBody_GiangVienThuocKhoaDaoTao,  GiangVienThuocKhoaDaoTao> reqBody_RemoveMany)
            {
                ResBody_RemoveMany<GiangVienThuocKhoaDaoTao> resBody_RemoveMany = new();
                if (reqBody_RemoveMany.ReturnJustIds)
                {
                    resBody_RemoveMany.ResultJustIds =  new List<long                    >();
                }
                else
                {
                    resBody_RemoveMany.Result        =  new List<GiangVienThuocKhoaDaoTao>();
                }
                //resBody_RemoveMany.NumberOfRowsAffected = await context.GiangVienThuocKhoaDaoTaos.Where(
                //reqBody_RemoveMany.FilterBy.MatchExpression()).ExecuteDeleteAsync();
                IQueryable<GiangVienThuocKhoaDaoTao> query =
                context   .GiangVienThuocKhoaDaoTaos
                .Where(reqBody_RemoveMany.FilterBy.MatchExpression());
                context   .GiangVienThuocKhoaDaoTaos
                .RemoveRange(query);
                resBody_RemoveMany.NumberOfRowsAffected = await context.SaveChangesAsync();
                return resBody_RemoveMany;
            }

        }
    }
}
