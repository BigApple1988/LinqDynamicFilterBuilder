using System.Collections.Generic;

namespace LinqDynamicFilterBuilder.Example.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IList<T> GetFiltered(IFilter<T> filter);
        T FindById(int id);
    }
}