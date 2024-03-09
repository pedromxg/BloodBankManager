using BloodBankManager.Core.Entities;

namespace BloodBankManager.Core.Services.Interfaces
{
    public interface IDonationService
    {
        Task<(Donation?, List<string>)> NewDonation(Donor donor, List<Donation> donations, DateTime donationDate, double amountDonated);
    }
}
