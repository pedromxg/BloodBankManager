using BloodBankManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Infrastructure.Persistence.Interfaces
{
    public interface IDonationRepository
    {
        Task<Donation> CreateAsync(Donation donation);
        Task<List<Donation>> GetAll();
        Task<List<Donation>> GetAllFromReferenceDate(DateTime referenceDate);
        Task<Donation> GetById(Guid id);
        Task Remove(Donation donation);
    }
}
