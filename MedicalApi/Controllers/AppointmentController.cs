using System;
using System.Collections.Generic;
using System.Linq;
using MedicalApi.Extensions;
using MedicalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    [Route("api/appointments")]
    public class AppointmentController : Controller
    {
        private static readonly List<Appointment> Appointments = new List<Appointment>
        {
            new Appointment
            {
                Id = 0,
                UserId = 0,
                PatientId = 0,
                Date = DateTimeOffset.Now,
                AdmissionTime = new AdmissionTime {StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(10) },
                DepartmentId = 1,
                IsCancelled = false,
                Note = "Note 1"
            },
            new Appointment
            {
                Id = 1,
                UserId = 0,
                PatientId = 1,
                Date = DateTimeOffset.Now,
                AdmissionTime = new AdmissionTime {StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) },
                DepartmentId = 1,
                IsCancelled = false,
                Note = "Note 2"
            },
            new Appointment
            {
                Id = 2,
                UserId = 0,
                PatientId = 2,
                Date = DateTimeOffset.Now,
                AdmissionTime = new AdmissionTime {StartTime = TimeSpan.FromHours(14), EndTime = TimeSpan.FromHours(15) },
                DepartmentId = 2,
                IsCancelled = false,
                Note = "Note 3"
            },

            new Appointment
            {
                Id = 3,
                UserId = 1,
                PatientId = 3,
                Date = DateTimeOffset.Now,
                AdmissionTime = new AdmissionTime {StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(10) },
                DepartmentId = 1,
                IsCancelled = false,
                Note = "Note 4"
            },

            new Appointment
            {
                Id = 4,
                UserId = 2,
                PatientId = 1,
                Date = DateTimeOffset.Now,
                AdmissionTime = new AdmissionTime {StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(10) },
                DepartmentId = 1,
                IsCancelled = false,
                Note = "Note 5"
            },

            new Appointment
            {
                Id = 3,
                UserId = 2,
                PatientId = 2,
                Date = DateTimeOffset.Now,
                AdmissionTime = new AdmissionTime {StartTime = TimeSpan.FromHours(12), EndTime = TimeSpan.FromHours(16) },
                DepartmentId = 1,
                IsCancelled = false,
                Note = "Note 6"
            }
        };

        [HttpPost]
        [Route("")]
        public Appointment AddAppointment([FromBody]Appointment appointment)
        {
            appointment.Id = Appointments.Count;
            Appointments.Add(appointment);

            return appointment;
        }

        [HttpGet]
        [Route("{date}")]
        public List<Appointment> GetAppointments(DateTimeOffset date, [FromQuery] string sortBy, [FromQuery] string order, [FromQuery] int skip, [FromQuery] int take)
        {
            var start = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
            var end = start.AddDays(1);

            var titleSortBy = sortBy.ToUpperFirst();
            var propertyInfo = typeof(Appointment).GetProperty(titleSortBy);
            var query = Appointments.Where(x => x.Date >= start && x.Date < end);

            query = order == "asc"
                ? query.OrderBy(x => propertyInfo.GetValue(x, null))
                : query.OrderByDescending(x => propertyInfo.GetValue(x, null));

            return query.Skip(skip).Take(take).ToList();
        }
    }
}