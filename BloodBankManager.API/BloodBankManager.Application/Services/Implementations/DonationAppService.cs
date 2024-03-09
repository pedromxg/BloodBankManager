using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Core.Services.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Interfaces;

namespace BloodBankManager.Application.Services.Implementations
{
    public class DonationAppService : IDonationAppService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodStockAppService _bloodStockAppService;
        private readonly IDonationService _donationService;

        public DonationAppService(IDonationRepository donationRepository, 
            IDonorRepository donorRepository, 
            IDonationService donationService, 
            IBloodStockAppService bloodStockAppService)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _donationService = donationService;
            _bloodStockAppService = bloodStockAppService;
        }

        public async Task<(List<string>, CreatedDonationViewModel?)> Create(NewDonationInputModel newDonationInputModel)
        {
            var donor = await _donorRepository.GetById(newDonationInputModel.DonorId);

            var registeredDonations = await _donationRepository.GetAll();

            var (newDonation, donationValidations) = await _donationService.NewDonation(donor, registeredDonations, newDonationInputModel.DonationDate, newDonationInputModel.AmountDonated);

            if (donationValidations.Any())
                return (donationValidations, new CreatedDonationViewModel());

            var createdDonation = await _donationRepository.CreateAsync(newDonation);

            _bloodStockAppService.UpdateStock(donor, newDonation);

            return (donationValidations, new CreatedDonationViewModel(createdDonation.Id));
        }

        public async Task<List<DonationViewModel>> GetAllInTheLastThirtyDays()
        {
            var referenceDate = DateTime.Now.AddDays(-30);

            var donations = await _donationRepository.GetAllFromReferenceDate(referenceDate);

            var donationsViewModelList = new List<DonationViewModel>();

            if (donations == null)
                return donationsViewModelList;

            foreach (var donation in donations)
            {
                var donationViewModel = new DonationViewModel(donation.DonorId, donation.AmountDonated, donation.Donor.BloodType, 
                    donation.DonationDate);

                donationsViewModelList.Add(donationViewModel);
            }

            return donationsViewModelList;
        }

        public async Task<DonationDetailsViewModel> GetById(Guid id)
        {
            var donation = await _donationRepository.GetById(id);

            if (donation == null)
            {
                return new DonationDetailsViewModel();
            }

            return new DonationDetailsViewModel();
        }

        public async Task Remove(Guid id)
        {
            var donation = await _donationRepository.GetById(id);

            await _donationRepository.Remove(donation);
        }
    }
}
