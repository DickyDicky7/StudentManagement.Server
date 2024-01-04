namespace StudentManagement.Server
{
    public static class Helper
    {
        public static Expression<Func<
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>,
            Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>>> AppendSetterProperty<TEntity>(
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>>> expressionL,
            Expression<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>>> expressionR)
        {
            var replaced = new Microsoft.EntityFrameworkCore.Query.ReplacingExpressionVisitor
                (expressionR.Parameters, new[] { expressionL.Body });
            var combined =
                replaced
                .Visit
                (expressionR
                .Body);
            return Expression.Lambda<Func<
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>,
                Microsoft.EntityFrameworkCore.Query.SetPropertyCalls<TEntity>>>(combined, expressionL.Parameters);
        }

    }
}
