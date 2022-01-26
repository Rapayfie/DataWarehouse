using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.MSSQL
{
    public class InsertBenchmark : Benchmark
    {
        #region Implementation
        [Benchmark(
            Description="Inserting records",
            SqlEquivalentStatement = SqlStatementsDescriptions.Insert,
            Values = new []{200, 500, 1000, 2000, 3000, 4000, 5000})]
        public void BenchmarkInsert(int numberOfRecords)
        {
            MSMSQLCRUD.CreatePatients(numberOfRecords, true);
        }
        #endregion
    }
}