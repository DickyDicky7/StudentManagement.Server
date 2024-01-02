namespace StudentManagement.Server.Bodies.Req.Common
{
    public record class ReqBody_UpdateMany<T1, T2> where T1 : BaseReqBody<T2> where T2 : class, IModel<T2>, new()
    {
        public T1   FilterBy      { get; set; } = null!;
        public T1   UpdateTo      { get; set; } = null!;
        public bool ReturnJustIds { get; set; }
    }
}
