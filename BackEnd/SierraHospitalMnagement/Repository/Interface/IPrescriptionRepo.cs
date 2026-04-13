using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext.Models;

namespace Repository.Interface
{
    public interface IPrescriptionRepo
    {
        Task<List<Prescription>> GetAllPrescriptions();
        Task<Prescription> CreatePrescription(Prescription prescription);
        Task<Prescription> UpdatePrescription(int id, Prescription prescription);

    }
}
