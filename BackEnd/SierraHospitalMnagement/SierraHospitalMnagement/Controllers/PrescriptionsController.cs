using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using DbContext.Models;

namespace SierraHospitalMnagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptions();
            return Ok(prescriptions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] Prescription prescription)
        {
            if (prescription == null)
            {
                return BadRequest();
            }
            var createdPrescription = await _prescriptionService.CreatePrescription(prescription);
            return CreatedAtAction(nameof(GetAllPrescriptions), new { id = createdPrescription.PrescriptionId }, createdPrescription);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] Prescription prescription)
        {
            if (prescription == null || id != prescription.PrescriptionId)
            {
                return BadRequest();
            }
            var updatedPrescription = await _prescriptionService.UpdatePrescription(id, prescription);
            if (updatedPrescription == null)
            {
                return NotFound();
            }
            return Ok(updatedPrescription);
        }
    }
}
