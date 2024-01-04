namespace StudentManagement.Server.Bodies.Req
{
    public abstract record class BaseReqBody<T> where T : class, IModel<T>, new()
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

        public abstract Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<T>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<T>>> UpdateModel();

        public abstract Expression<Func<T, bool>> MatchExpression();

        public virtual T ToModel()
        {
            T model = new();
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                model.GetType()
                     .GetProperty(propertyInfo.Name)!
                     .SetValue(model, propertyInfo.GetValue(this));
            }
            return model;
        }
    }
}
