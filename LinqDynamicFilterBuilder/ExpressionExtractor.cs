using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LinqDynamicFilterBuilder
{
    public class ExpressionExtractor
    {
        private static readonly MethodInfo ContainsMethod = typeof(string).GetMethod("Contains");
        private static readonly MethodInfo StartsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo EndsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

        private static MemberExpression GetEndpointProperty(ParameterExpression param, ExpressionFilter filter)
        {
            var properties = filter.PropertyName.Split('.');
            if (properties.Length == 0)
            {
                return null;
            }
            var expression = Expression.Property(param, properties[0]);
            for (var i = 1; i < properties.Length; i++)
            {
                expression = Expression.Property(expression, properties[i]);
            }
            return expression;
        }

        public static Expression GetExpression<T>(ParameterExpression param, ExpressionFilter filter)
        {

            MemberExpression member = GetEndpointProperty(param, filter);
            ConstantExpression constant = Expression.Constant(filter.Value, member.Type);
            switch (filter.ComparisonType)
            {
                case ComparisonType.Equal:
                    return Expression.Equal(member, constant);
                case ComparisonType.GreaterThan:
                    return Expression.GreaterThan(member, constant);
                case ComparisonType.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);
                case ComparisonType.LessThan:
                    return Expression.LessThan(member, constant);
                case ComparisonType.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);
                case ComparisonType.NotEqual:
                    return Expression.NotEqual(member, constant);
                case ComparisonType.Contains:
                    return Expression.Call(member, ContainsMethod, constant);
                case ComparisonType.StartsWith:
                    return Expression.Call(member, StartsWithMethod, constant);
                case ComparisonType.EndsWith:
                    return Expression.Call(member, EndsWithMethod, constant);
                default:
                    return null;
            }
        }
    }

}
