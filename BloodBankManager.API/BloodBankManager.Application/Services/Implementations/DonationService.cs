using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Services.Implementations
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;

        public async Task<(bool, CreatedDonationViewModel?)> Create(NewDonationInputModel newDonationInputModel)
        {
            var registeredDonations = _donationRepository.GetAll().Result;

            var donor = await _donorRepository.GetById(newDonationInputModel.DonorId);

            var canDonate = !registeredDonations.Exists(r => r.DonationDate.Equals(newDonationInputModel.DonationDate) && r.DonorId.Equals(newDonationInputModel.DonorId));

            if (!canDonate)
                return (canDonate, null);

            var createdDonation = await _donationRepository.Create(newDonationInputModel.DonationDate, newDonationInputModel.AmountDonated, donor);

            return (canDonate, new CreatedDonationViewModel(createdDonation.Id));
        }

        public async Task<List<DonationViewModel>> GetAll()
        {
            var donations = await _donationRepository.GetAll();

            var donationsViewModelList = new List<DonationViewModel>();

            if (donations == null)
                return donationsViewModelList;

            foreach (var donation in donations)
            {
                var donorViewModel = new DonationViewModel();

                donationsViewModelList.Add(donorViewModel);
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
