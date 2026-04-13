using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }
    }
}
