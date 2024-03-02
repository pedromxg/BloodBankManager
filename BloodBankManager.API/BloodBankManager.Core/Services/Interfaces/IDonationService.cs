using BloodBankManager.Core.Entities;

namespace BloodBankManager.Core.Services.Interfaces
{
    public interface IDonationService
    {
        Task<(bool, Donation)> NewDonation(Donor donor, List<Donation> donations, BloodStock bloodStock);
    }
}
