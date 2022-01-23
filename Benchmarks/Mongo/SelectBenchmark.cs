using System.Threading.Tasks;
using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MongoDB;

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
            //MongoCRUD.DeleteAllRecords();
            //MongoCRUD.CreatePatients(100, true);
        }
        
        [Benchmark(
            Description="Selecting all records in Patients table",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithoutDependencies)]
        public void BenchmarkSelectAllPatients()
        {
            MongoCRUD.SelectAllPatients();
        }
        
        [Benchmark(
            Description="Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies)]
        public void BenchmarkSelectAllPatients_WithDependencies()
        {
            MongoCRUD.SelectAllPatientsWithDependencies();
        }
        
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with a letter and result is returned by patient address order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress)]
        public void BenchmarkSelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress()
        {
            MongoCRUD.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress();
        }
        
        #endregion
    }
}