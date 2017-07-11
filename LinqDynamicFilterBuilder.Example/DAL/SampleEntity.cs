using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LinqDynamicFilterBuilder.Example.DAL
{
    public class SampleEntity
    {
        [Key]
        public int SampleEntityId { get; set; }
        public SampleVirtualEntity SampleVirtualEntity { get; set; }
    }
}