using Microsoft.AspNetCore.Mvc;
using SCAN.Repositories.PatientRepository;

namespace SCAN.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateAppointment()
        {
            return View();
        }
    }
}
