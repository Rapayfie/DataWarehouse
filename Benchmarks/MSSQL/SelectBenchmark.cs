using DataWarehouse.Databases.MongoDB;

namespace DataWarehouse.Benchmarks.MSSQL
{
    public class SelectBenchmark
    {
        public SelectBenchmark()
        {
            
        }
        
        private void PrepareDb()
        {
            MongoCRUD.DeleteAllRecords();
            MongoCRUD.CreatePatients(15, true);
        }
    }
}