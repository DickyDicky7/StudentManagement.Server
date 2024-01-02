namespace StudentManagement.Server.Bodies.Res
{
    public record class ResBody_GetMany<T> where T : class, IModel<T>, new()
    {
        public IEnumerable<T> Result { get; set; } = null!;
    }
}
