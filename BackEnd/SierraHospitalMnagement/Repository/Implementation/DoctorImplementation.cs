using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using DbContext.Models;

namespace Repository.Implementation
{
    public class DoctorImplementation : IDoctorRepo
    {
        private readonly SQLDBContext _context;

        public DoctorImplementation(SQLDBContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctor(int id, Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(id);
            if (existingDoctor == null)
            {
                return null;
            }

            existingDoctor.DoctorName = doctor.DoctorName;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.Specialization = doctor.Specialization;

            await _context.SaveChangesAsync();
            return existingDoctor;
        }
    }
}