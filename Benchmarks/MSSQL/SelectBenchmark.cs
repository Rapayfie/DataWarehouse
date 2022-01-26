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
            Description=$"Selecting all records in Patients without dependencies where age greater than 50 and first name starts with B " +
                        $"and result is returned by patient first name then last name order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB,
            Values = new []{200, 500, 1000, 2000, 3000, 4000, 5000})]
        public void SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB()
        {
            MSMSQLCRUD.SelectAllPatients();
        }
        
        
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with A letter and has no end value date and any disease hospital history start with A letter " +
                        $"and result is returned by patient first name then last name order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress,
            Values = new []{200, 500, 1000, 2000, 3000, 4000, 5000})]
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