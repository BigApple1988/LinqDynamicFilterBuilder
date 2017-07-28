using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqDynamicFilterBuilder
{
    public class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> CreateExpressionTree<T>(List<ExpressionFilter> filters)
        {
            if (filters.Count == 0)
                return null;
            if (filters.All(filter => filter.ComparisonType == ComparisonType.Skip))
            {
                return null;
            }
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            foreach (var expressionFilter in filters)
            {
                if(expressionFilter.ComparisonType==ComparisonType.Skip) continue;
                if (expressionFilter.Value != null)
                {
                    if (exp == null)
                        exp = ExpressionExtractor.GetExpression<T>(param, expressionFilter);
                    else
                    {
                        exp = Expression.And(exp, ExpressionExtractor.GetExpression<T>(param, expressionFilter));
                    }

                }
            }
            return Expression.Lambda<Func<T, bool>>(exp, param);
        }
    }
}