using System;

namespace MedicalApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public DateTimeOffset Date { get; set; }
        public AdmissionTime AdmissionTime { get; set; }
        public int DepartmentId { get; set; }
        public bool IsCancelled { get; set; }
        public string Note { get; set; }
    }
}
