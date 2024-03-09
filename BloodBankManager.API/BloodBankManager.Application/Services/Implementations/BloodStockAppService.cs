using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Core.Entities;
using BloodBankManager.Infrastructure.Persistence.Interfaces;

namespace BloodBankManager.Application.Services.Implementations
{
    public class BloodStockAppService : IBloodStockAppService
    {
        private readonly IBloodStockRepository _bloodStockRepository;

        public BloodStockAppService(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task UpdateStock(Donor donor, Donation newDonation)
        {
            var bloodStockByType = await _bloodStockRepository.GetByType(donor.BloodType);

            if (bloodStockByType == null)
            {
                var newBloodStock = new BloodStock(donor.BloodType, donor.RhFactor, newDonation.AmountDonated);

                _bloodStockRepository.CreateAsync(newBloodStock);
            }
            else
            {
                bloodStockByType.UpdateAmountInStock(newDonation.AmountDonated);

                _bloodStockRepository.UpdateAsync(bloodStockByType);
            }
        }
    }
}
