using System;
using DataWarehouse.Databases.MongoDB;
using DataWarehouse.Databases.MSSQL;
using MongoDB.Bson.Serialization.Attributes;

namespace DataWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert operations benchmark
            OperationsBenchmark.BencharkInsertMSSQLOperation();
            OperationsBenchmark.BenchmarkInsertMongoOperation();
            //Update operations benchmark
            //Delete operations benchmark
        }
    }
}