namespace StudentManagement.Server.Bodies.Res.Common
{
    public record class ResBody_UpdateMany<T> where T : class, IModel<T>, new()
    {
        //public int NumberOfRowsAffected             { get; set; }
        //public IEnumerable<T   > ResultBeforeUpdate { get; set; } = null!;
        //public IEnumerable<T   > ResultAfter_Update { get; set; } = null!;
        //public IEnumerable<long> ResultJustIds      { get; set; } = null!;

        public int NumberOfRowsAffected        { get; set; }
        public IEnumerable<T   > Result        { get; set; } = null!;
        public IEnumerable<long> ResultJustIds { get; set; } = null!;
    }
}
