using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DbContext.Models;

namespace Repository.Interface
{
    public interface IAppointmentRepo
    {
        Task<List<AppointmentDto>> GetAllAppointments();
        Task<AppointmentDto> GetAppointmentById(int id);
        Task<AppointmentDto> CreateAppointment(Appointment appointment);
        Task<AppointmentDto> UpdateAppointment(int id, Appointment appointment);
        Task<bool> DeleteAppointment(int id);
    }
}
