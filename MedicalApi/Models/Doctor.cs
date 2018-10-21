using System;

namespace MedicalApi.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public DateTimeOffset BirthDate { get; set; }
        
        public DateTimeOffset EmployementDate { get; set; }
        
        public DateTimeOffset WorkingStartDate { get; set; }
        
        public bool IsRetired { get; set; }
    }
}
