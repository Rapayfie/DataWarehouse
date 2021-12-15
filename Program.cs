using System;
using DataWarehouse.Databases.MongoDB;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert operations benchmark
            InsertOperationsBenchmarkFactory.BencharkInsertMSSQLOperation();
            //OperationsBenchmark.BenchmarkInsertMongoOperation();
            //Update operations benchmark
            //Delete operations benchmark
            
            //Dispose
            Console.WriteLine("Do you wish to dispose the data? press y/n");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine("Deleting the data in the databases...");
                MSMSQLCRUD.Dispose();
                MongoCRUD.Dispose();
            }
            else
            {
                Console.WriteLine("Keeping the data in the databases :)");
            }
        }
    }
}