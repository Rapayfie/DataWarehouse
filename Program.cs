using DataWarehouse.Benchmarks;
using InsertBenchmarkMongoDb = DataWarehouse.Benchmarks.Mongo.InsertBenchmark;
using InsertBenchmarkMSSQL = DataWarehouse.Benchmarks.MSSQL.InsertBenchmark;
using SelectBenchmarkMongoDb = DataWarehouse.Benchmarks.Mongo.SelectBenchmark;
using SelectBenchmarkMSSQL = DataWarehouse.Benchmarks.MSSQL.SelectBenchmark;

//BenchmarkRunner.Run<InsertBenchmarkMongoDb>();
//BenchmarkRunner.Run<InsertBenchmarkMSSQL>();
//BenchmarkRunner.Run<SelectBenchmarkMongoDb>();
BenchmarkRunner.Run<SelectBenchmarkMSSQL>();