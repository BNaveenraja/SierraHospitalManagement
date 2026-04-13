using DbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IPatientRepo
    {
        Task<List<Patient>> GetAllPatients();
        Task<Patient> CreatePatient(Patient patient);
        Task<Patient> UpdatePatient(int id, Patient patient);
    }
}
