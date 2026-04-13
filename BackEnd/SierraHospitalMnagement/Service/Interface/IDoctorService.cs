using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> CreateDoctor(Doctor doctor);
        Task<Doctor> UpdateDoctor(int id, Doctor doctor);
    }
}
