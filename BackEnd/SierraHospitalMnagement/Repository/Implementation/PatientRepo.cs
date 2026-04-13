using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly SQLDBContext _context;

        public PatientRepo(SQLDBContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatient(int id, Patient patient)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
            {
                return null;
            }
            existingPatient.PatientName = patient.PatientName;
            existingPatient.Email = patient.Email;
            existingPatient.Phone = patient.Phone;
            existingPatient.Address = patient.Address;
            await _context.SaveChangesAsync();
            return existingPatient;
        }
    }
}
