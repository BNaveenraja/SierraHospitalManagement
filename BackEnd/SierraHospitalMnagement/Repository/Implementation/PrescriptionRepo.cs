using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class PrescriptionRepo : IPrescriptionRepo
    {
        private readonly SQLDBContext _context;

        public PrescriptionRepo(SQLDBContext context)
        {
            _context = context;
        }

        public async Task<List<Prescription>> GetAllPrescriptions()
        {
            return await _context.Prescriptions.ToListAsync();
        }

        public async Task<Prescription> CreatePrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription> UpdatePrescription(int id, Prescription prescription)
        {
            var existingPrescription = await _context.Prescriptions.FindAsync(id);
            if (existingPrescription == null)
            {
                return null;
            }
            existingPrescription.AppointmentId = prescription.AppointmentId;
            existingPrescription.Medication = prescription.Medication;
            existingPrescription.Dosage = prescription.Dosage;
            existingPrescription.Frequency = prescription.Frequency;
            await _context.SaveChangesAsync();
            return existingPrescription;
        }
    }
}
