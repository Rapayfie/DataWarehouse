using System;
using System.Collections.Generic;
using System.Linq;
using DataWarehouse.Models;

namespace DataWarehouse
{
    public static class DataGenerator
    {
        private static readonly Random Gen;
        private static readonly DateTime StartDate;
        private static readonly int DateRange;
        
        static DataGenerator()
        {
            Gen = new Random();
            StartDate = new DateTime(1995, 1, 1);
            DateRange = (DateTime.Today - StartDate).Days;
        }
        
        public static IEnumerable<DiseaseHospitalHistory> GenerateDiseaseHistory(int count)
        {
            var result = new List<DiseaseHospitalHistory>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new DiseaseHospitalHistory()
                {
                    Id = Guid.NewGuid(),
                    HospitalName = $"{RandomString()} {RandomString()}",
                    StayFrom = RandomDate(),
                    StayTo = RandomDate(),
                    Description = RandomString()
                });
            }

            return result;
        }
        
        public static IEnumerable<Disease> GenerateDisease(int count)
        {
            int diseaseHistoryCount = 5;
            var result = new List<Disease>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Disease()
                {
                    Id = Guid.NewGuid(),
                    Name = $"{RandomString()} {RandomString()}",
                    StartDate = RandomDate(),
                    EndDate = RandomEndDate(),
                    DiseaseHospitalHistory = GenerateDiseaseHistory(diseaseHistoryCount)
                });
            }

            return result;
        }
        
        public static IEnumerable<Patient> GeneratePatients(int count)
        {
            int diseaseCount = 5;
            var result = new List<Patient>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Patient
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"{RandomString()} {RandomString()}",
                    LastName = $"{RandomString()} {RandomString()}",
                    Address = $"{RandomString()} {Gen.Next(0, 500)}",
                    Age = Gen.Next(0, 100),
                    Diseases = GenerateDisease(diseaseCount)
                });
            }

            return result;
        }
        
        public static DateTime RandomDate()
        {
            return StartDate.AddDays(Gen.Next(DateRange));
        }
        
        public static string RandomString()
        {
            var oneWordLength = 6;
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = Enumerable.Range(0, oneWordLength)
                .Select(x => pool[Gen.Next(0, pool.Length)]);
            
            return new string(chars.ToArray());
        }

        public static DateTime? RandomEndDate()
        {
            var rand = Gen.Next(0, 100);
            if (rand % 2 == 0 && rand is > 30 and < 80)
            {
                return null;
            }

            return RandomDate();
        }
    }
}