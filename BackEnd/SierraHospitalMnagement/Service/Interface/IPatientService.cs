using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> CreatePatient(Patient patient);
        Task<Patient> UpdatePatient(int id, Patient patient);
    }
}
