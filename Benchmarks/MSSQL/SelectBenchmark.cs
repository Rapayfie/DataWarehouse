using DataWarehouse.Commons.Attributes;
using DataWarehouse.Databases.MSSQL;

namespace DataWarehouse.Benchmarks.MSSQL
{
    public class SelectBenchmark : Benchmark
    {
        #region Constructor
        public SelectBenchmark()
        {
            MSMSQLCRUD.DeleteAllRecords();
        }
        #endregion

        #region Implementation
        
        [Benchmark(
            Description=$"Selecting all records in Patients",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB,
            Values = new []{10, 20, 30, 40, 50, 60, 100, 150})]
        public void SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB()
        {
            MSMSQLCRUD.SelectAllPatients();
        }
        
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with a letter and result is returned by patient address order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress,
            Values = new []{10, 20, 30, 40, 50, 60, 100, 150})]
        public void SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress()
        {
            MSMSQLCRUD.SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress();
        }
        
        public void PrepareDb(int numberOfRecords)
        {
            MSMSQLCRUD.DeleteAllRecords();
            MSMSQLCRUD.CreatePatients(numberOfRecords, true);
        }
        #endregion
    }
}