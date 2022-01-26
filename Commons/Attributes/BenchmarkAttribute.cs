using System;

namespace DataWarehouse.Commons.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BenchmarkAttribute : Attribute
    {
        public BenchmarkAttribute(
            string description = null,
            string sqlEquivalentStatement = null,
            params int[] values)
        {
            Description = description;
            SqlEquivalentStatement = sqlEquivalentStatement;
            Values = values;
        }
        
        public string Description { get; set; }
        public string SqlEquivalentStatement { get; set; }
        public int[] Values { get; set; }
    }
}