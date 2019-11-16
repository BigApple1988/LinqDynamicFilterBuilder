#region

using LinqDynamicFilterBuilder.Example.DAL;
using LinqDynamicFilterBuilder.Example.Interfaces;

#endregion

namespace LinqDynamicFilterBuilder.Example.Repositories
{
    public class SampleRepository : BaseRepository<SampleEntity>
    {
        public SampleRepository(ExampleContext context) : base(context)
        {
        }
    }
}