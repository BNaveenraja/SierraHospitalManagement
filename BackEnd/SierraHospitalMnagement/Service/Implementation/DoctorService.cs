using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;
using Repository.Interface;
using DbContext.Models;

namespace Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _doctorRepo.GetAllDoctors();
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            return await _doctorRepo.CreateDoctor(doctor);
        }

        public async Task<Doctor> UpdateDoctor(int id, Doctor doctor)
        {
            return await _doctorRepo.UpdateDoctor(id, doctor);
        }
    }
}
