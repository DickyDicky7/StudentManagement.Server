using System.Reflection;

namespace StudentManagement.Server.Bodies.Req
{
    public abstract record class BaseReqBody<T1, T2> where T2 : IModel<T2>
    {
        public virtual bool Match(T2 model)
        {
            bool matchingResult = true;
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(this) != null)
                {
                    matchingResult =
                    matchingResult && Object.Equals(propertyInfo.GetValue(this), model.GetType().
                    GetProperty(propertyInfo.Name)!.GetValue(model));
                }
                if (!matchingResult)
                {
                    break;
                }
            }
            return matchingResult;
        }

        public abstract Func<T1, Expression<Func<T2, bool>>> MatchExpression { get; set; }
    }
}
