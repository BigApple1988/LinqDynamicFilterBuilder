#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LinqDynamicFilterBuilder.Example.DAL;
using LinqDynamicFilterBuilder.Example.Interfaces;

#endregion

namespace LinqDynamicFilterBuilder.Example.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ExampleContext _exampleContext;

        protected BaseRepository(ExampleContext context)
        {
            _exampleContext = context;
        }

        public IList<T> GetFiltered(IFilter<T> filter)
        {
            var expressionTree = GetExpression(filter);
            return GetFilteredQuery(expressionTree).ToList();
        }

        public T FindById(int id)
        {
            var classProperties = typeof(T).GetProperties();
            var idProp = classProperties.FirstOrDefault(p => p.IsDefined(typeof(KeyAttribute)));
            if (idProp == null)
            {
                idProp = classProperties.FirstOrDefault(i => i.Name.Equals($"{typeof(T).Name}Id"));
                if (idProp == null)
                    throw new NullReferenceException("Id property is not defined");
            }

            var expressionTree = ExpressionBuilder.CreateExpressionTree<T>(new List<ExpressionFilter>
            {
                new ExpressionFilter
                {
                    ComparisonType = ComparisonType.Equal,
                    PropertyName = idProp.Name,
                    Value = id
                }
            });


            return GetFilteredQuery(expressionTree).FirstOrDefault();
        }

        public Expression<Func<T, bool>> GetExpression(IFilter<T> filter)
        {
            var filters = new List<ExpressionFilter>();

            if (filter != null)
            {
                var props = filter.GetType().GetProperties();
                foreach (var propertyInfo in props)
                {
                    var value = propertyInfo.GetValue(filter);
                    var propertyName = propertyInfo.Name;
                    if (value == null)
                    {
                        continue;
                    }

                    var attribute = propertyInfo.GetCustomAttribute<ComparisonAttribute>();
                    var comparison = ComparisonType.Equal;

                    if (attribute != null)
                    {
                        comparison = attribute.ComparisonType;
                        if (!string.IsNullOrEmpty(attribute.PropertyName))
                        {
                            propertyName = attribute.PropertyName;
                        }
                    }

                    filters.Add(new ExpressionFilter()
                    {
                        ComparisonType = comparison,
                        PropertyName = propertyName,
                        Value = value
                    });
                }
            }

            var expressionTree = ExpressionBuilder.CreateExpressionTree<T>(filters);
            return expressionTree;
        }

        public virtual IQueryable<T> GetFilteredQuery(Expression<Func<T, bool>> expression)
        {
            var query = (IQueryable<T>) _exampleContext.Set<T>();
            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query;
        }
    }
}