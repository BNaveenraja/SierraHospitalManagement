using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepo _prescriptionRepo;
        public PrescriptionService(IPrescriptionRepo prescriptionRepo)
        {
            _prescriptionRepo = prescriptionRepo;
        }

        public async Task<List<Prescription>> GetAllPrescriptions()
        {
            return await _prescriptionRepo.GetAllPrescriptions();
        }

        public async Task<Prescription> CreatePrescription(Prescription prescription)
        {
            return await _prescriptionRepo.CreatePrescription(prescription);
        }

        public async Task<Prescription> UpdatePrescription(int id, Prescription prescription)
        {
            return await _prescriptionRepo.UpdatePrescription(id, prescription);
        }
    }
}
