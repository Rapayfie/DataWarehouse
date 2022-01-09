using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.MSSQL
{
    public class InsertBenchmark
    {
        [Benchmark(
            Description="This method tests how fast inserting 1000 records into db works",
            SqlEquivalentStatement = @"
                INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...)")]
        public void BenchmarkInsertMongoOperation_OneLevelOnly_5_Times()
        {
            MSMSQLCRUD.CreatePatients(1000, false);
        }
        
        [Benchmark(
            Description="This method tests how fast inserting 3 levels of data each consisting of 10 records, " +
                        "so 10*10*10 = 1000 records inserted into db works",
            SqlEquivalentStatement = @"
                INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...)")]
        public void BenchmarkInsertMongoOperation_ThreeLevels_10_Times_Each()
        {
            MSMSQLCRUD.CreatePatients(10, true);
        }
        
        [Benchmark(
            Description="This method tests how fast inserting 3 levels of data each consisting of 25 records, " +
                        "so 25*25*25 = 15 625 records inserted into db works",
            SqlEquivalentStatement = @"
                INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...)")]
        public void BenchmarkInsertMongoOperation_ThreeLevels_25_Times_Each()
        {
            MSMSQLCRUD.CreatePatients(25, true);
        }
    }
}