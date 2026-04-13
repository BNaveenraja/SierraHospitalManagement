using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using Service.Interface;
using DbContext.Models;
using Repository.Interface;

namespace Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        public AppointmentService(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }
        public async Task<List<AppointmentDto>> GetAllAppointments()
        {
            return await _appointmentRepo.GetAllAppointments();
        }
        public async Task<AppointmentDto> GetAppointmentById(int id)
        {
            return await _appointmentRepo.GetAppointmentById(id);
        }
        public async Task<AppointmentDto> CreateAppointment(Appointment appointment)
        {
            return await _appointmentRepo.CreateAppointment(appointment);
        }
        public async Task<AppointmentDto> UpdateAppointment(int id, Appointment appointment)
        {
            return await _appointmentRepo.UpdateAppointment(id, appointment);
        }
        public async Task<bool> DeleteAppointment(int id)
        {
            return await _appointmentRepo.DeleteAppointment(id);
        }
    }
}
