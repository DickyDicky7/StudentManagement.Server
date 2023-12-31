using System.Reflection;

namespace StudentManagement.Server.Bodies.Req
{
    public abstract record class BaseReqBody<T> where T : IModel<T>
    {
        public virtual bool Match(T model)
        {
            bool matchingResult = true;
            foreach (PropertyInfo propertyInfo in GetType().GetProperties())
            {
                if (propertyInfo.GetValue(this) != null)
                {
                    matchingResult =
                    matchingResult && Equals(propertyInfo.GetValue(this), propertyInfo.GetValue(model));
                }
                if (!matchingResult)
                {
                    break;
                }
            }
            return matchingResult;
        }
    }
}
