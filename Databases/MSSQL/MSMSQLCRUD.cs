using System;
using System.IO;
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
            var result = PatientRepository.Query(
                filter: p=> p.Age > 50 && p.FirstName.StartsWith("B"),
                orderBy: p=> p.OrderBy(fn => fn.FirstName).ThenBy(ln => ln.LastName))
                .ToList();
        }

        public static void SelectAllPatients_WithDependencies_Where_AnyDiseaseStartsWithAletter_AndHasNoEndValue_AndAnyDiseaseHospitalHistoryStartsWithALetter_OrderByPatientAddress()
        {
            var result = PatientRepository.Query(
                filter:
                p =>
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