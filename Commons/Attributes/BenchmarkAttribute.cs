using System;

namespace DataWarehouse.Commons.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BenchmarkAttribute : Attribute
    {
        public BenchmarkAttribute(
            string description = null,
            string sqlEquivalentStatement = null)
        {
            Description = description;
            SqlEquivalentStatement = sqlEquivalentStatement;
        }
        
        public string Description { get; set; }
        public string SqlEquivalentStatement { get; set; }
    }
}