using System;

namespace DataWarehouse.Commons.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OrdererAttribute : Attribute
    {
        public OrdererAttribute(
            SummaryOrderPolicy summaryOrderPolicy = SummaryOrderPolicy.Default)
        {
            SummaryOrderPolicy = summaryOrderPolicy;
        }
        
        private SummaryOrderPolicy SummaryOrderPolicy { get; }
    }
    
    public enum SummaryOrderPolicy
    {
        Default,
        FastestToSlowest,
        SlowestToFastest
    }
}