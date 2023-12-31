﻿namespace StudentManagement.Server.API
{
    public static class API_ChuyenNganh
    {
        public static WebApplication MapAPI_ChuyenNganh(this WebApplication app)
        {
            app
                .MapPost(@"/chuyen-nganh/get-many", InternalMethods.ChuyenNganh_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<ChuyenNganh>> ChuyenNganh_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_ChuyenNganh reqBody)
            {
                Common.ResBody<ChuyenNganh> resBody = new()
                {
                    Result = await context.ChuyenNganhs
                    .Where(chuyenNganh => reqBody
                    .Match(chuyenNganh))
                    .Skip(offset).Take(limit).ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
