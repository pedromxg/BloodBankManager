using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;

namespace BloodBankManager.Application.Services.Interfaces
{
    public interface IBloodStockAppService
    {
        Task UpdateStock(Donor donor, Donation newDonation);
    }
}
