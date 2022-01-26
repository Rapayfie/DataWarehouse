using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MongoDB;

namespace DataWarehouse.Benchmarks.Mongo
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
            MongoCRUD.CreatePatients(numberOfRecords, true);
        }
        #endregion
    }
}