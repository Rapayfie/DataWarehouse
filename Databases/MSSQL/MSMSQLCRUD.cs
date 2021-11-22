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
            PatientRepository.InsertMany(DataGenerator.GeneratePatients(5));
        }
    }
}