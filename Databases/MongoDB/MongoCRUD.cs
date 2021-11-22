using DataWarehouse.Models;

namespace DataWarehouse.Databases.MongoDB
{
    public static class MongoCRUD
    {
        private static readonly Repository<Patient> PatientRepository;
        private static readonly Repository<Disease> DiseaseRepository;
        private static readonly Repository<DiseaseHospitalHistory> DiseaseHospitalHistoryRepository;

        static MongoCRUD()
        {
            PatientRepository = new Repository<Patient>("Patients");
            DiseaseRepository = new Repository<Disease>("Diseases");
            DiseaseHospitalHistoryRepository = new Repository<DiseaseHospitalHistory>("DiseaseHospitalHistories");
        }

        public static void CreatePatients()
        {
            PatientRepository.InsertMany(DataGenerator.GeneratePatients(5));
        }
    }
}