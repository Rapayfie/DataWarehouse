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
        
        public static void SelectPatients()
        {
            var queryResult = PatientRepository.Query(
                filter:
                x => 
                    x.Diseases.Any(y => y.Name.StartsWith("a")),
                orderBy:
                a => a
                    .OrderBy(b => b.Address),
                include:
                z => z
                    .Include(x => x.Diseases)
                    .ThenInclude(d => d.DiseaseHospitalHistory));
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