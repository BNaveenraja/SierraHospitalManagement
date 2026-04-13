using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;

namespace Service.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientRepo.GetAllPatients();
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            return await _patientRepo.CreatePatient(patient);
        }

        public async Task<Patient> UpdatePatient(int id, Patient patient)
        {
            return await _patientRepo.UpdatePatient(id, patient);
        }
    }
}