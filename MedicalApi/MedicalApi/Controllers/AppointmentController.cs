using System;
using System.Collections.Generic;
using System.Linq;
using MedicalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    [Route("api/appointments")]
    public class AppointmentController : Controller
    {
        private static readonly List<Appointment> Appointments = new List<Appointment>();

        [HttpPost]
        [Route("")]
        public Appointment AddAppointment([FromBody]Appointment appointment)
        {
            appointment.Id = Appointments.Count;
            Appointments.Add(appointment);

            return appointment;
        }

        [HttpGet]
        [Route("date")]
        public List<Appointment> GetAppointments(DateTimeOffset date)
        {
            var start = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
            var end = start.AddDays(1);

            return Appointments.Where(x => x.Date >= start && x.Date < end).ToList();
        }
    }
}