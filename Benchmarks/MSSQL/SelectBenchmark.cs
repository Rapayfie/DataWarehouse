using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.MSSQL
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
            //MSMSQLCRUD.DeleteAllRecords();
            //MSMSQLCRUD.CreatePatients(100, true);
        }
        
        /*
        [Benchmark(
            Description="Selecting all records in Patients table",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithoutDependencies)]
        public void BenchmarkSelectAllPatients()
        {
            MSMSQLCRUD.SelectAllPatients();
        }
        
        [Benchmark(
            Description="Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies)]
        public void BenchmarkSelectAllPatients_WithDependencies()
        {
            MSMSQLCRUD.SelectAllPatientsWithDependencies();
        }
        
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with a letter and result is returned by patient address order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress)]
        public void BenchmarkSelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress()
        {
            MSMSQLCRUD.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress();
        }
        */
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with a letter and result is returned by patient address order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress)]
        public void BenchmarkSelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress2()
        {
            MSMSQLCRUD.SelectAllPatientsWhere();
        }
        
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with a letter and result is returned by patient address order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress)]
        public void BenchmarkSelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress3()
        {
            MSMSQLCRUD.SelectAllPatientsWhere2();
        }
        #endregion
    }
}