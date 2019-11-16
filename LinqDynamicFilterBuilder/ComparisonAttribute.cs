#region

using System;

#endregion

namespace LinqDynamicFilterBuilder
{
    public class ComparisonAttribute : Attribute
    {
        public ComparisonAttribute(ComparisonType comparisonType)
        {
            ComparisonType = comparisonType;
        }

        public ComparisonAttribute(ComparisonType comparisonType, string propertyName)
        {
            ComparisonType = comparisonType;
            PropertyName = propertyName;
        }

        public ComparisonType ComparisonType { get; set; }
        public string PropertyName { get; set; }
    }
}