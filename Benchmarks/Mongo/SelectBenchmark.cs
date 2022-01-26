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
            MongoCRUD.DeleteAllRecords();
        }
        #endregion

        #region Implementation
        [Benchmark(
            Description=$"Selecting all records in Patients without dependencies where age greater than 50 and first name starts with B " +
                        $"and result is returned by patient first name then last name order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB,
            Values = new []{10, 20, 30, 40, 50, 60, 100, 150})]
        public void SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB()
        {
            MongoCRUD.SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB();
        }
        
        [Benchmark(
            Description=$"Selecting all records in Patients with dependencies this is Diseases and DiseaseHospitalHistories tables" +
                        $"where disease starts with A letter and has no end value and any disease hospital history start with a letter " +
                        $"and result is returned by patient first name then last name order ascending",
            SqlEquivalentStatement = SqlStatementsDescriptions.SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress,
            Values = new []{10, 20, 30, 40, 50, 60, 100, 150})]
        public void SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress()
        {
            MongoCRUD.SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress();
        }
        
        public void PrepareDb(int numberOfRecords)
        {
            MongoCRUD.DeleteAllRecords();
            MongoCRUD.CreatePatients(numberOfRecords, true);
        }
        #endregion
    }
}