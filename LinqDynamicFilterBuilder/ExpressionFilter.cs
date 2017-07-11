namespace LinqDynamicFilterBuilder
{
    public class ExpressionFilter
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        public ComparisonType ComparisonType { get; set; }
    }
}