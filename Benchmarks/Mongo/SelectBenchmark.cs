using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.Mongo
{
    public class SelectBenchmark
    {
        public SelectBenchmark()
        {
            PrepareDb();
        }

        private void PrepareDb()
        {
            MSMSQLCRUD.DeleteAllRecords();
            MSMSQLCRUD.CreatePatients(15, true);
        }
    }
}