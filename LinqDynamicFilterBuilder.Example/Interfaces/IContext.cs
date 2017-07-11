using System.Linq;

namespace LinqDynamicFilterBuilder.Example.Interfaces
{
    public interface IContext
    {
        IQueryable<T> Set<T>() where T:class;
    }
}
