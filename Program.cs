using DataWarehouse.Benchmarks;
using InsertBenchmarkMongoDb = DataWarehouse.Benchmarks.Mongo.InsertBenchmark;
using InsertBenchmarkMSSQL = DataWarehouse.Benchmarks.MSSQL.InsertBenchmark;
using SelectBenchmarkMongoDb = DataWarehouse.Benchmarks.Mongo.SelectBenchmark;
using SelectBenchmarkMSSQL = DataWarehouse.Benchmarks.MSSQL.SelectBenchmark;

await BenchmarkRunner.Run<InsertBenchmarkMongoDb>();
await BenchmarkRunner.Run<InsertBenchmarkMSSQL>();
await BenchmarkRunner.Run<SelectBenchmarkMongoDb>();
await BenchmarkRunner.Run<SelectBenchmarkMSSQL>();