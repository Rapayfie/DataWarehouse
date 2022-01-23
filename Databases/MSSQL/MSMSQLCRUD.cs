using System.Linq;
using DataWarehouse.Commons.Generators;
using DataWarehouse.Models;
using Microsoft.EntityFrameworkCore;

namespace DataWarehouse.Databases.MSSQL
{
    public static class MSMSQLCRUD
    {
        #region Fields
        private static readonly Repository<Patient> PatientRepository;
        private static readonly Repository<Disease> DiseaseRepository;
        private static readonly Repository<DiseaseHospitalHistory> DiseaseHospitalHistoryRepository;
        #endregion

        #region Constructor
        static MSMSQLCRUD()
        {
            PatientRepository = new Repository<Patient>();
            DiseaseRepository = new Repository<Disease>();
            DiseaseHospitalHistoryRepository = new Repository<DiseaseHospitalHistory>();
        }
        #endregion

        #region Implementation
        public static void CreatePatients(int count, bool includeChildElements = false)
        {
            PatientRepository.InsertMany(DataGenerator.GeneratePatients(count, includeChildElements));
        }
        public static void SelectAllPatients()
        {
            var result = PatientRepository.Query();
        }
        
        public static void SelectAllPatientsWhere()
        {
            var result = PatientRepository.Query(
                filter:
                x => x.Age > 20,
                take: 2);
        }
        
        public static void SelectAllPatientsWhere2()
        {
            var result = PatientRepository.Query(
                filter:
                x => x.Age > 20);
        }
        
        public static void SelectAllPatientsWithDependencies()
        {
            var result = PatientRepository.Query(
                include:
                z => z
                    .Include(x => x.Diseases)
                    .ThenInclude(d => d.DiseaseHospitalHistory));
        }
        
        public static void SelectAllPatients_WithDependencies_WhereDiseaseStartsWith_A_letter_OrderByPatientAddress()
        {
            var result = PatientRepository.Query(
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