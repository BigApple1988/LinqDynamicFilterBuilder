#region

using System.Collections.Generic;
using System.Linq;
using LinqDynamicFilterBuilder.Example.Interfaces;

#endregion

namespace LinqDynamicFilterBuilder.Example.DAL
{
    public class ExampleContext : IContext
    {
        public IQueryable<SampleEntity> SampleEntities { get; set; }

        public IQueryable<T> Set<T>() where T : class
        {
            return (IQueryable<T>) SampleEntities;
        }
    }
}