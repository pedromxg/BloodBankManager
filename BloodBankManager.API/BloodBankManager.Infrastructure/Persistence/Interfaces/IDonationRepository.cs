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
        Task<Donation> Create(DateTime donationDate, double amountDonated, Donor donor);
        Task<List<Donation>> GetAll();
        Task<Donation> GetById(Guid id);
        Task Remove(Donation donation);
    }
}
