#region

using System.Linq;

#endregion

namespace LinqDynamicFilterBuilder.Example.Interfaces
{
    public interface IContext
    {
        IQueryable<T> Set<T>() where T : class;
    }
}