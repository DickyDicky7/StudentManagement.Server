using System.Reflection;

namespace StudentManagement.Server.Bodies.Req
{
    public abstract record class BaseReqBody<T> where T : IModel<T>
    {
        public virtual bool Match(T model)
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
    }
}
