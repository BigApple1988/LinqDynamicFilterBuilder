using System;

namespace LinqDynamicFilterBuilder
{
    public class ComparisonAttribute :Attribute
    {
        public ComparisonType ComparisonType { get; set; }
        public string PropertyName { get; set; }

        public ComparisonAttribute(ComparisonType comparisonType)
        {
            ComparisonType = comparisonType;
        }

        public ComparisonAttribute(ComparisonType comparisonType, string propertyName)
        {
            ComparisonType = comparisonType;
            PropertyName = propertyName;
        }
    }
}
