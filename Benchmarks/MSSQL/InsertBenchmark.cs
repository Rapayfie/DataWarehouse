using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.MSSQL
{
    public class InsertBenchmark : Benchmark
    {
        #region Implementation
        [Benchmark(
            Description="Inserting 1000 records to single table",
            SqlEquivalentStatement = SqlStatementsDescriptions.Insert)]
        public void BenchmarkInsertMongoOperation_OneLevelOnly_1000_Times()
        {
            MSMSQLCRUD.CreatePatients(1000, false);
        }
        
        [Benchmark(
            Description="Inserting 3 levels of data each consisting of 10 records, so 10*10*10 = 1000 records total",
            SqlEquivalentStatement = SqlStatementsDescriptions.Insert)]
        public void BenchmarkInsertMongoOperation_ThreeLevels_10_Times_Each()
        {
            MSMSQLCRUD.CreatePatients(10, true);
        }
        
        [Benchmark(
            Description="Inserting 3 levels of data each consisting of 10 records, so 25*25*25 = 15 625 records total",
            SqlEquivalentStatement = SqlStatementsDescriptions.Insert)]
        public void BenchmarkInsertMongoOperation_ThreeLevels_25_Times_Each()
        {
            MSMSQLCRUD.CreatePatients(25, true);
        }
        #endregion
        
    }
}