using System;
using System.Collections.Generic;

namespace SierraHospitalMnagement.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? AppointmentId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string? Dosage { get; set; }

    public string? Duration { get; set; }

    public virtual Appointment? Appointment { get; set; }
}
