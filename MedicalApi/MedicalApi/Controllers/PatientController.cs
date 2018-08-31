using System;
using System.Collections.Generic;
using System.Linq;
using MedicalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    [Route("api/patients")]
    public class PatientController : Controller
    {
        private static readonly IEnumerable<Patient> Patients = new List<Patient>
        {
            new Patient
            {
                Id = 0, FirstName = "Nana", LastName = "Richter",
                BirthDate = new DateTimeOffset(1982, 1, 12, 0, 0, 0, TimeSpan.Zero)
            },
            new Patient
            {
                Id = 1, FirstName = "Jack", LastName = "Diggins",
                BirthDate = new DateTimeOffset(1977, 5, 1, 0, 0, 0, TimeSpan.Zero)
            },
            new Patient
            {
                Id = 2, FirstName = "Maire", LastName = "Crespo",
                BirthDate = new DateTimeOffset(1991, 2, 23, 0, 0, 0, TimeSpan.Zero)
            },
            new Patient
            {
                Id = 3, FirstName = "Jung", LastName = "Corey",
                BirthDate = new DateTimeOffset(1964, 11, 30, 0, 0, 0, TimeSpan.Zero)
            },
            new Patient
            {
                Id = 3, FirstName = "Kera", LastName = "Epperly",
                BirthDate = new DateTimeOffset(1964, 11, 30, 0, 0, 0, TimeSpan.Zero)
            },
            new Patient
            {
                Id = 3, FirstName = "Ilene", LastName = "Justice",
                BirthDate = new DateTimeOffset(1964, 11, 30, 0, 0, 0, TimeSpan.Zero)
            }
        };

        [HttpGet]
        [Route("id")]
        public Patient GetPatient(int id)
        {
            return Patients.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet]
        [Route("")]
        public List<Patient> GetPatients()
        {
            return Patients.ToList();
        }
    }
}