using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MongoDB;

namespace DataWarehouse.Benchmarks.Mongo
{
    public class InsertBenchmark : Benchmark
    {
        [Benchmark(
            Description="This method tests how fast inserting 1000 records into db works",
            SqlEquivalentStatement = @"
                INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...)
                Executed 1000 times")]
        public void BenchmarkInsertMongoOperation_OneLevelOnly_5_Times()
        {
            MongoCRUD.CreatePatients(1000, false);
        }
        
        [Benchmark(
            Description="This method tests how fast inserting 3 levels of data each consisting of 10 records, " +
                        "so 10*10*10 = 1000 records inserted into db works",
            SqlEquivalentStatement = @"
                INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...)
                Executed 1000 times")]
        public void BenchmarkInsertMongoOperation_ThreeLevels_10_Times_Each()
        {
            MongoCRUD.CreatePatients(10, true);
        }
        
        [Benchmark(
            Description="This method tests how fast inserting 3 levels of data each consisting of 25 records, " +
                        "so 25*25*25 = 15 625 records inserted into db works",
            SqlEquivalentStatement = @"
                INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...)
                Executed 15 625 times")]
        public void BenchmarkInsertMongoOperation_ThreeLevels_25_Times_Each()
        {
            MongoCRUD.CreatePatients(25, true);
        }
    }
}