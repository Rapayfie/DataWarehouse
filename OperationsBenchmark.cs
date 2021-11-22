﻿using System;
using DataWarehouse.Databases.MongoDB;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse
{
    public static class OperationsBenchmark
    {
        static OperationsBenchmark()
        {
            
        }
        
        public static void BencharkInsertMSSQLOperation()
        {
            Console.WriteLine("--> Beginning BencharkInsertMSSQLOperation operation");
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MSMSQLCRUD.CreatePatients();
            watch.Stop();
            
            Console.WriteLine($"Finished BencharkInsertMSSQLOperation operation. Elapsed time: " +
                              $"{watch.ElapsedMilliseconds}");
        }

        public static void BenchmarkInsertMongoOperation()
        {
            Console.WriteLine("--> Beginning BenchmarkInsertMongoOperation operation");
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MongoCRUD.CreatePatients();
            watch.Stop();
            
            Console.WriteLine($"Finished BenchmarkInsertMongoOperation operation. Elapsed time: " +
                              $"{watch.ElapsedMilliseconds}");
        }
    }
}