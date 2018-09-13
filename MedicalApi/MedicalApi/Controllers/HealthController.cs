using Microsoft.AspNetCore.Mvc;

namespace MedicalApi.Controllers
{
    public class HealthController : Controller
    {
        public IActionResult Ping => Ok();
    }
}