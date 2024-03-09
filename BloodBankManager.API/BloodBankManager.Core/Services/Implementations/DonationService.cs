using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Services.Interfaces;

namespace BloodBankManager.Core.Services.Implementations
{
    public class DonationService : IDonationService
    {
        public Task<(Donation?, List<string>)> NewDonation(Donor donor, List<Donation> donations, DateTime donationDate, double amountDonated)
        {
            var donationsValidation = ValidationsForMakingDonations(donor, donations, donationDate);

            if (donationsValidation.Any())
                return Task.FromResult<(Donation?, List<string>)>((null, donationsValidation));

            var newDonation = new Donation(donationDate, amountDonated, donor);

            return Task.FromResult<(Donation?, List<string>)>((newDonation, donationsValidation));
        }

        public List<string> ValidationsForMakingDonations(Donor donor, List<Donation> donations, DateTime donationDate)
        {
            var donationsValidation = new List<string>();

            var hasMinimalAge = ((DateTime.Today - donor.DateOfBirth).Days / 365) >= 18;

            if (hasMinimalAge)
            {
                donationsValidation.Add("É necessário ter 18 anos ou mais para realizar uma doação.");
            }

            var hasMinimalWeitgh = donor.Weight >= 50;

            if (hasMinimalWeitgh)
            {
                donationsValidation.Add("É necessário ter pesar no mínimo 50 kg para realizar uma doação.");
            }

            var hasMinimalBreakBetweenDonations = !donations.Exists(r => r.DonationDate.Equals(donationDate) && r.DonorId.Equals(donor.Id));

            if (hasMinimalBreakBetweenDonations)
            {
                donationsValidation.Add("Não é permitido realizar mais de uma doação no mesmo dia.");
            }

            return donationsValidation;
        }
    }
}
