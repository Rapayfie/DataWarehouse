using System;
using System.Collections.Generic;

namespace DataWarehouse.Models
{
    public record Disease
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<DiseaseHospitalHistory> DiseaseHospitalHistory { get; set; }
    }
}