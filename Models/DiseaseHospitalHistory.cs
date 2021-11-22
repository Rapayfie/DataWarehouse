using System;

namespace DataWarehouse.Models
{
    public class DiseaseHospitalHistory
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public DateTime StayFrom { get; set; }
        public DateTime StayTo { get; set; }
        public string Description { get; set; }
    }
}