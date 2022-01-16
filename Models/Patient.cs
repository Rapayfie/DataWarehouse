using System;
using System.Collections.Generic;

namespace DataWarehouse.Models
{
    public record Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public IEnumerable<Disease> Diseases { get; set; }
    }
}