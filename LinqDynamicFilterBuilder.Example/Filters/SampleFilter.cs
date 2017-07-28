using LinqDynamicFilterBuilder.Example.DAL;
using LinqDynamicFilterBuilder.Example.Interfaces;

namespace LinqDynamicFilterBuilder.Example.Filters
{
    public class SampleFilter :IFilter<SampleEntity>
    {
        public int? SampleEntityId { get; set; }
        [Comparison(ComparisonType.GreaterThan,"SampleVirtualEntity.SampleVirtualEntityId")]
        public int? VirtualEntityId { get; set; }
        [Comparison(ComparisonType.Skip)]
        public bool? SkippedProperty { get; set; }
    }
}