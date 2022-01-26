using System.Linq;
using DataWarehouse.Commons.Generators;
using DataWarehouse.Models;
using Microsoft.EntityFrameworkCore;

namespace DataWarehouse.Databases.MongoDB
{
    public static class MongoCRUD
    {
        #region Fields
        private static readonly Repository<Patient> PatientRepository;
        private static readonly Repository<Disease> DiseaseRepository;
        private static readonly Repository<DiseaseHospitalHistory> DiseaseHospitalHistoryRepository;
        #endregion

        #region Constructor
        static MongoCRUD()
        {
            PatientRepository = new Repository<Patient>("Patients");
            DiseaseRepository = new Repository<Disease>("Diseases");
            DiseaseHospitalHistoryRepository = new Repository<DiseaseHospitalHistory>("DiseaseHospitalHistories");
        }
        #endregion

        #region Implementation
        public static void CreatePatients(int count, bool includeChildElements = false)
        {
            PatientRepository.InsertMany(
                DataGenerator.GeneratePatients(count, includeChildElements));
        }
        
        public static void SelectAllPatients_WithoutDependencies_Where_AgeGreaterThan50_And_FirstNameStartsWithB()
        {
            var result = PatientRepository.Query(
                    filter: p=> p.Age > 50 && p.FirstName.StartsWith("B") && p.LastName.StartsWith("B"),
                    orderBy: p=> p.OrderBy(fn => fn.FirstName).ThenBy(ln => ln.LastName))
                .ToList();
        }

        public static void SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress()
        {
            var result = PatientRepository.Query(
                    filter:
                    p => p.Age > 50 && p.FirstName.StartsWith("B") && p.LastName.StartsWith("B") &&
                        p.Diseases.Any(d => d.Name.StartsWith("A")
                                            && !d.EndDate.HasValue &&
                                            d.DiseaseHospitalHistory.Any(
                                                dh => dh.Description.StartsWith("A"))),
                    orderBy:
                    p => p
                        .OrderBy(fn => fn.FirstName).ThenBy(ln => ln.LastName),
                    include:
                    z => z
                        .Include(d => d.Diseases)
                        .ThenInclude(dh => dh.DiseaseHospitalHistory))
                .ToList();
        }
        
        public static void DeleteAllRecords()
        {
            PatientRepository.DeleteAll();
            DiseaseRepository.DeleteAll();
            DiseaseHospitalHistoryRepository.DeleteAll();
        }
        #endregion
    }
}