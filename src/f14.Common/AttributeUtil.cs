using System.Linq.Expressions;
using System.Reflection;

namespace f14
{
    /// <summary>
    /// Provides helper methods for work with attributes.
    /// </summary>
    public static class AttributeUtil
    {
        /// <summary>
        /// Gets a collection of attributes from the enum value.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <typeparam name="TEnum">Type of enum object.</typeparam>
        /// <param name="enumValue">Enum value.</param>
        /// <returns>Collection of attributes.</returns>
        public static TAttribute[] GetAttributesFromEnumValue<TAttribute, TEnum>(TEnum enumValue)
            where TAttribute : Attribute
            where TEnum : Enum
        {
            var field = typeof(TEnum).GetTypeInfo().GetField(enumValue.ToString());
            if (field != null)
            {
                var attrs = field.GetCustomAttributes(typeof(TAttribute), false);
                return attrs.Cast<TAttribute>().ToArray();
            }
            return Array.Empty<TAttribute>();
        }

        /// <summary>
        /// Gets a single attribute from type.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <typeparam name="TTarget">Type of the target object.</typeparam>
        /// <returns>Single attribute.</returns>
        public static TAttribute? GetAttribute<TAttribute, TTarget>() where TAttribute : Attribute => typeof(TTarget).GetTypeInfo().GetCustomAttribute<TAttribute>();

        /// <summary>
        /// Gets a collection of attributes from type.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <typeparam name="TTarget">Type of object where need to find an attribute.</typeparam>
        /// <param name="inherit">Include inherit attributes.</param>
        /// <returns>Single attribute.</returns>
        public static TAttribute? GetAttribute<TAttribute, TTarget>(bool inherit) where TAttribute : Attribute => typeof(TTarget).GetTypeInfo().GetCustomAttribute<TAttribute>(inherit);

        /// <summary>
        /// Gets a collection of attributes for the specified class member.
        /// </summary>
        /// <typeparam name="TAttribute">Type of attribute.</typeparam>
        /// <typeparam name="TTarget">Type of object where need to find an attribute.</typeparam>        
        /// <param name="property">Member selector.</param>
        /// <param name="inherit">Include inherit attributes.</param>
        /// <returns>Collection of attributes.</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute, TTarget>(Expression<Func<TTarget, object?>> property, bool inherit)
            where TAttribute : Attribute
        {
            var me = ExpressionHelper.GetMemberExpression(property);
            if (me != null)
            {
                var memberName = me.Member.Name;
                var ti = typeof(TTarget).GetTypeInfo();
                MemberInfo? mi = null;

                switch (me.Member.MemberType)
                {
                    case MemberTypes.Event:
                        mi = ti.GetEvent(memberName);
                        break;
                    case MemberTypes.Field:
                        mi = ti.GetField(memberName);
                        break;
                    case MemberTypes.Property:
                        mi = ti.GetProperty(memberName);
                        break;
                }

                if (mi != null)
                {
                    return mi.GetCustomAttributes<TAttribute>(inherit);
                }
            }

            return [];
        }
    }
}
