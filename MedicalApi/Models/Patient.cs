using System;

namespace MedicalApi.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }
}
