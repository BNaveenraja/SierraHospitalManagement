using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext.Models;

namespace Service.Interface
{
    public interface IPrescriptionService
    {
        Task<List<Prescription>> GetAllPrescriptions();
        Task<Prescription> CreatePrescription(Prescription prescription);
        Task<Prescription> UpdatePrescription(int id, Prescription prescription);
    }
}
