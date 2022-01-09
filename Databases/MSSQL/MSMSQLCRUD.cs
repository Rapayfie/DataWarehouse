using System.Threading;
using DataWarehouse.Commons.Generators;
using DataWarehouse.Models;

namespace DataWarehouse.Databases.MSSQL
{
    public static class MSMSQLCRUD
    {
        private static readonly Repository<Patient> PatientRepository;
        private static readonly Repository<Disease> DiseaseRepository;
        private static readonly Repository<DiseaseHospitalHistory> DiseaseHospitalHistoryRepository;

        static MSMSQLCRUD()
        {
            PatientRepository = new Repository<Patient>();
            DiseaseRepository = new Repository<Disease>();
            DiseaseHospitalHistoryRepository = new Repository<DiseaseHospitalHistory>();
        }

        public static void CreatePatients(int count, bool includeChildElements = false)
        {
            PatientRepository.InsertMany(DataGenerator.GeneratePatients(5, includeChildElements));
        }

        public static void DeleteAllRecords()
        {
            PatientRepository.DeleteAll();
            DiseaseRepository.DeleteAll();
            DiseaseHospitalHistoryRepository.DeleteAll();
        }
    }
}