using System.Linq.Expressions;

namespace f14
{
    /// <summary>
    /// Provides helper methods for expressions.
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Creates setter action.
        /// </summary>
        /// <typeparam name="TObject">Object type.</typeparam>
        /// <typeparam name="TProperty">Property type.</typeparam>
        /// <param name="property">Property accessor.</param>
        /// <returns>The setter action.</returns>
        public static Action<TObject, TProperty>? CreateSetter<TObject, TProperty>(Expression<Func<TObject, TProperty>> property) => CreateSetterExpression(property)?.Compile();

        /// <summary>
        /// Creates setter expression.
        /// </summary>
        /// <typeparam name="TObject">Object type.</typeparam>
        /// <typeparam name="TProperty">Property type.</typeparam>
        /// <param name="property">Property accessor.</param>
        /// <returns>The setter expression.</returns>
        public static Expression<Action<TObject, TProperty>>? CreateSetterExpression<TObject, TProperty>(Expression<Func<TObject, TProperty>> property)
        {
            var me = GetMemberExpression(property);
            if (me != null)
            {
                var paramObject = Expression.Parameter(typeof(TObject), "entity");
                var paramPropertyValue = Expression.Parameter(typeof(TProperty), "value");

                var assignAction = Expression.Assign(Expression.PropertyOrField(paramObject, me.Member.Name), paramPropertyValue);

                return Expression.Lambda<Action<TObject, TProperty>>(assignAction, paramObject, paramPropertyValue);
            }
            return null;
        }

        /// <summary>
        /// Tries get <see cref="MemberExpression"/> from given param.
        /// </summary>
        /// <param name="expression">Expression to analyze.</param>
        /// <returns><see cref="MemberExpression"/> or null.</returns>
        public static MemberExpression? GetMemberExpression(Expression expression)
        {
            if (expression is LambdaExpression lambdaExp)
            {
                Expression temp = lambdaExp.Body;

                if (temp is MemberExpression me)
                {
                    return me;
                }

                if (temp is UnaryExpression ue)
                {
                    return ue.Operand as MemberExpression;
                }

                return null;
            }

            return expression as MemberExpression;
        }

        /// <summary>
        /// Tries to get the <see cref="MemberExpression"/> for the given type.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="expression">Member expression.</param>
        /// <returns><see cref="MemberExpression"/> or null.</returns>
        public static MemberExpression? GetMemberExpression<T>(Expression<Func<T, object?>> expression)
        {
            if (expression is LambdaExpression)
            {
                Expression temp = expression.Body;

                if (temp is MemberExpression me)
                {
                    return me;
                }

                if (temp is UnaryExpression ue)
                {
                    return ue.Operand as MemberExpression;
                }

                return null;
            }

            return expression as MemberExpression;
        }
    }
}
