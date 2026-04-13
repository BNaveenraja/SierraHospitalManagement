using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace SierraHospitalMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
        {
            var createdPatient = await _patientService.CreatePatient(patient);
            return CreatedAtAction(nameof(GetAllPatients), new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            var updatedPatient = await _patientService.UpdatePatient(id, patient);
            if (updatedPatient == null)
            {
                return NotFound();
            }
            return Ok(updatedPatient);
        }
    }
}
