using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.Mongo
{
    public class SelectBenchmark : Benchmark
    {
        #region Constructor
        public SelectBenchmark()
        {
            PrepareDb();
        }
        #endregion

        #region Implementation
        private void PrepareDb()
        {
            MSMSQLCRUD.DeleteAllRecords();
            MSMSQLCRUD.CreatePatients(15, true);
        }
        
        public void Bench()
        {
            MSMSQLCRUD.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress();
        }
        #endregion
    }
}