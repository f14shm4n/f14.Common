using System;
using System.Linq.Expressions;

namespace f14.Common
{
    /// <summary>
    /// Provides helper methods for expressions.
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Creates setter action.
        /// </summary>
        /// <typeparam name="O">Object type.</typeparam>
        /// <typeparam name="P">Property type.</typeparam>
        /// <param name="property">Property accessor.</param>
        /// <returns>The setter action.</returns>
        public static Action<O, P>? CreateSetter<O, P>(Expression<Func<O, P>> property) => CreateSetterExpression(property)?.Compile();

        /// <summary>
        /// Creates setter expression.
        /// </summary>
        /// <typeparam name="OType">Object type.</typeparam>
        /// <typeparam name="PType">Property type.</typeparam>
        /// <param name="property">Property accessor.</param>
        /// <returns>The setter expression.</returns>
        public static Expression<Action<OType, PType>>? CreateSetterExpression<OType, PType>(Expression<Func<OType, PType>> property)
        {
            var me = GetMemberExpression(property);
            if (me != null)
            {
                var paramObject = Expression.Parameter(typeof(OType), "entity");
                var paramPropertyValue = Expression.Parameter(typeof(PType), "value");

                var assignAction = Expression.Assign(Expression.PropertyOrField(paramObject, me.Member.Name), paramPropertyValue);

                return Expression.Lambda<Action<OType, PType>>(assignAction, paramObject, paramPropertyValue);
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
