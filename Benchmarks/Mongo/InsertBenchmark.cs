using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MongoDB;

namespace DataWarehouse.Benchmarks.Mongo
{
    public class InsertBenchmark : Benchmark
    {
        #region Implementation
        [Benchmark(
            Description="Inserting 1000 records to single table",
            SqlEquivalentStatement = SqlStatementsDescriptions.Insert,
            Values = new []{10, 20, 30, 40, 50, 60, 100, 150})]
        public void BenchmarkInsert(int numberOfRecords)
        {
            MongoCRUD.CreatePatients(numberOfRecords, true);
        }
        #endregion
    }
}