using f14.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <typeparam name="TMemberInfo">Type of the member info, for example: <see cref="PropertyInfo"/>.</typeparam>
        /// <param name="property">Member selector.</param>
        /// <param name="inherit">Include inherit attributes.</param>
        /// <returns>Collection of attributes.</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute, TTarget, TMemberInfo>(Expression<Func<TTarget, object?>> property, bool inherit)
            where TAttribute : Attribute
            where TMemberInfo : MemberInfo
        {
            var me = ExpressionHelper.GetMemberExpression(property);
            if (me != null)
            {
                var memberName = me.Member.Name;
                var memberInfoType = typeof(TMemberInfo);
                var ti = typeof(TTarget).GetTypeInfo();
                MemberInfo? mi = null;

                if (typeof(PropertyInfo).IsAssignableFrom(memberInfoType))
                {
                    mi = ti.GetProperty(memberName);
                }
                else if (typeof(FieldInfo).IsAssignableFrom(memberInfoType))
                {
                    mi = ti.GetField(memberName);
                }
                else if (typeof(FieldInfo).IsAssignableFrom(memberInfoType))
                {
                    mi = ti.GetMethod(memberName);
                }

                if (mi != null)
                {
                    return mi.GetCustomAttributes<TAttribute>(inherit);
                }
            }

            return Enumerable.Empty<TAttribute>();
        }
    }
}
