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

        public static void CreatePatients()
        {
            DiseaseHospitalHistoryRepository.InsertMany(DataGenerator.GenerateDiseaseHistory(5));
        }

        public static void Dispose()
        {
            PatientRepository.DeleteAll();
            DiseaseRepository.DeleteAll();
            DiseaseHospitalHistoryRepository.DeleteAll();
        }
    }
}