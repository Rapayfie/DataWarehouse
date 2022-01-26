using System;
using System.Collections.Generic;
using System.Linq;
using DataWarehouse.Models;

namespace DataWarehouse.Commons.Generators
{
    public static class DataGenerator
    {
        #region Fields
        private static readonly Random Gen;
        private static readonly DateTime StartDate;
        private static readonly int DateRange;
        #endregion

        #region Constructor
        static DataGenerator()
        {
            Gen = new Random();
            StartDate = new DateTime(1995, 1, 1);
            DateRange = (DateTime.Today - StartDate).Days;
        }
        #endregion

        #region Implementation

        private static IEnumerable<DiseaseHospitalHistory> GenerateDiseaseHistory(int count)
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

        private static IEnumerable<Disease> GenerateDisease(int count)
        {
            var result = new List<Disease>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Disease()
                {
                    Id = Guid.NewGuid(),
                    Name = $"{RandomString()} {RandomString()}",
                    StartDate = RandomDate(),
                    EndDate = RandomEndDate(),
                    DiseaseHospitalHistory = GenerateDiseaseHistory(5)
                });
            }

            return result;
        }
        
        public static IEnumerable<Patient> GeneratePatients(int count, bool includeChildElements = true)
        {
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
                    Diseases = includeChildElements ? GenerateDisease(5) : null
                });
            }

            return result;
        }

        private static DateTime RandomDate()
        {
            return StartDate.AddDays(Gen.Next(DateRange));
        }

        private static string RandomString()
        {
            var oneWordLength = 6;
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = Enumerable.Range(0, oneWordLength)
                .Select(x => pool[Gen.Next(0, pool.Length)]);
            
            return new string(chars.ToArray());
        }

        private static DateTime? RandomEndDate()
        {
            var rand = Gen.Next(0, 100);
            if (rand % 2 == 0 && rand is > 30 and < 80)
            {
                return null;
            }

            return RandomDate();
        }
        #endregion
        
    }
}