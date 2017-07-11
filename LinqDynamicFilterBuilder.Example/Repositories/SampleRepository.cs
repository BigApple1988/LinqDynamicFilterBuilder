using LinqDynamicFilterBuilder.Example.DAL;
using LinqDynamicFilterBuilder.Example.Interfaces;

namespace LinqDynamicFilterBuilder.Example.Repositories
{
    public class SampleRepository :BaseRepository<SampleEntity>
    {
        public SampleRepository(ExampleContext context) : base(context)
        {
        }
    }
}