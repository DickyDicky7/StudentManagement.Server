namespace StudentManagement.Server.Bodies.Req
{
    public record class ReqBody_AddMany<T1, T2> where T1 : BaseReqBody<T2> where T2 : class, IModel<T2>, new()
    {
        public IEnumerable<T1> ItemsToAdd { get; set; } = null!;
        public bool ReturnJustIds         { get; set; }
    }
}
