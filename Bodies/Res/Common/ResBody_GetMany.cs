namespace StudentManagement.Server.Bodies.Res.Common
{
    public record class ResBody_GetMany<T> where T : class, IModel<T>, new()
    {
        public IEnumerable<T> Result { get; set; } = null!;
    }
}
