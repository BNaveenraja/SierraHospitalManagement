using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using Repository.Interface;
using DbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Implementation
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly SQLDBContext _context;

        public AppointmentRepo(SQLDBContext context)
        {
            _context = context;
        }

        public async Task<List<AppointmentDto>> GetAllAppointments()
        {
            return await _context.Appointments
                .Select(a => new AppointmentDto
                {
                    AppointmentId = a.AppointmentId,
                    DoctorId = a.DoctorId,
                    PatientId = a.PatientId,
                    AppointmentDate = a.AppointmentDate,
                    Status = a.Status,
                    Notes = a.Notes
                })
                .ToListAsync();
        }
        public async Task<AppointmentDto> GetAppointmentById(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return null;
            }
            return new AppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Notes = appointment.Notes
            };
        }

        public async Task<AppointmentDto> CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return new AppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                DoctorId = appointment.DoctorId.DoctorName,
                PatientId = appointment.PatientId.PatientName,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Notes = appointment.Notes
            };
        }

        public async Task<AppointmentDto> UpdateAppointment(int id, Appointment appointment)
        {
            var existingAppointment = await _context.Appointments.FindAsync(id);
            if (existingAppointment == null)
            {
                return null;
            }
            existingAppointment.PatientId = appointment.PatientId;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.AppointmentDate = appointment.AppointmentDate;
            existingAppointment.Reason = appointment.Reason;
            await _context.SaveChangesAsync();
            return new AppointmentDto
            {
                AppointmentId = existingAppointment.AppointmentId,
                DoctorId = existingAppointment.DoctorId,
                PatientId = existingAppointment.PatientId,
                AppointmentDate = existingAppointment.AppointmentDate,
                Status = existingAppointment.Status,
                Notes = existingAppointment.Notes
            };
        }

        public async Task<bool> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return false;
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
