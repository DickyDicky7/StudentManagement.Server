namespace StudentManagement.Server.Bodies.Res
{
    public record class ResBody_GetMany<T> where T : IModel<T>
    {
        public IEnumerable<T> Result { get; set; } = null!;
    }
}
