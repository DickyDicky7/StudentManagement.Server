namespace StudentManagement.Server.API
{
    public static class API_BoMon
    {
        public static WebApplication MapAPI_BoMon(this WebApplication app)
        {
            app
                .MapPost(@"/bo-mon/get-many", InternalMethods.BoMon_GetMany)
                .WithTags(@"Get many");

            return app;
        }

        private class InternalMethods
        {
            public static async Task<Common.ResBody<BoMon>> BoMon_GetMany(
                [FromServices] ApplicationDbContext context,
                [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "limit")] int limit,
                [FromBody] ReqBody_BoMon reqBody)
            {
                Common.ResBody<BoMon> resBody = new()
                {
                    Result = await context.BoMons
                    .Where(boMon => reqBody
                    .Match(boMon))
                    .Skip(offset).Take(limit).ToListAsync(),
                };
                return resBody;
            }
        }
    }
}
