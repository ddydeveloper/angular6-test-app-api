using System;
using System.Collections.Generic;
using System.Linq;
using MedicalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    [Route("api/doctors")]
    public class DoctorController : Controller
    {
        private static readonly IEnumerable<Doctor> Doctors = new List<Doctor>
        {
            new Doctor
            {
                Id = 0, FirstName = "John", LastName = "Jones",
                BirthDate = new DateTimeOffset(1982, 1, 12, 0, 0, 0, TimeSpan.Zero), IsRetired = false
            },
            new Doctor
            {
                Id = 1, FirstName = "Jack", LastName = "Jackson",
                BirthDate = new DateTimeOffset(1977, 5, 1, 0, 0, 0, TimeSpan.Zero), IsRetired = false
            },
            new Doctor
            {
                Id = 2, FirstName = "Philip", LastName = "Filmer",
                BirthDate = new DateTimeOffset(1991, 2, 23, 0, 0, 0, TimeSpan.Zero), IsRetired = false
            },
            new Doctor
            {
                Id = 3, FirstName = "Abraham", LastName = "Lincoln",
                BirthDate = new DateTimeOffset(1964, 11, 30, 0, 0, 0, TimeSpan.Zero), IsRetired = false
            },
            new Doctor
            {
                Id = 3, FirstName = "Abraham Retired", LastName = "Lincoln Retired",
                BirthDate = new DateTimeOffset(1964, 11, 30, 0, 0, 0, TimeSpan.Zero), IsRetired = true
            },
            new Doctor
            {
                Id = 3, FirstName = "Philip Retired", LastName = "Lincoln Retired",
                BirthDate = new DateTimeOffset(1964, 11, 30, 0, 0, 0, TimeSpan.Zero), IsRetired = true
            }
        };

        [HttpGet]
        [Route("{id}")]
        public Doctor GetDoctor(int id)
        {
            return Doctors.FirstOrDefault(x => x.Id == id && !x.IsRetired);
        }

        [HttpGet]
        [Route("")]
        public List<Doctor> GetDoctors()
        {
            return Doctors.Where(x => !x.IsRetired).ToList();
        }
    }
}