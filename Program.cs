using DataWarehouse.Benchmarks;
using InsertBenchmarkMongoDb = DataWarehouse.Benchmarks.Mongo.InsertBenchmark;

namespace DataWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<InsertBenchmarkMongoDb>();

            //Console.WriteLine("Deleting the data in the databases...");
            //MSMSQLCRUD.Dispose();
            //MongoCRUD.Dispose();
        }
    }
}