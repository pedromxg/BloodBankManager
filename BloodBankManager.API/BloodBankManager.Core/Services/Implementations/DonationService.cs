using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Services.Interfaces;

namespace BloodBankManager.Core.Services.Implementations
{
    public class DonationService : IDonationService
    {
        public async Task<(bool, Donation)> NewDonation(Donor donor, List<Donation> donations, BloodStock bloodStock)
        {
            
        }
    }
}
