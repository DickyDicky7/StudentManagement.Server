namespace StudentManagement.Server.Bodies.Res.Common
{
    public record class ResBody_Helper<T> where T : class
    {
        public T Result { get; set; } = null!;
    }
}
