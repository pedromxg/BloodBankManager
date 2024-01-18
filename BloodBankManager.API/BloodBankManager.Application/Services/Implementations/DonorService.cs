using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Application.ViewModels;
using BloodBankManager.Core.Entities;
using BloodBankManager.Infrastructure.Persistence.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Repositories;

namespace BloodBankManager.Application.Services.Implementations
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        public async Task<List<DonorViewModel>> GetAll()
        {
            var donors = await _donorRepository.GetAll();

            var donorsViewModelList = new List<DonorViewModel>();

            if (donors == null)
                return donorsViewModelList;

            foreach (var donor in donors)
            {
                var donorViewModel = new DonorViewModel(donor.Name, donor.BloodType, donor.RhFactor);

                donorsViewModelList.Add(donorViewModel);
            }
            
            return donorsViewModelList;
        }

        public async Task<DonorDetailsViewModel> GetById(Guid id)
        {
            var donor = await _donorRepository.GetById(id);

            return new DonorDetailsViewModel(donor.Name, donor.Email, donor.DateOfBirth, donor.Gender, donor.Weight, donor.BloodType,
                donor.RhFactor, donor.Adress);
        }

        public async Task<CreatedDonorViewModel> Create(NewDonorInputModel newDonorInputModel)
        {
            var createdDonor = await _donorRepository.Create(newDonorInputModel.Name,
                newDonorInputModel.Email,
                newDonorInputModel.DateOfBirth,
                newDonorInputModel.Gender,
                newDonorInputModel.Weight,
                newDonorInputModel.BloodType,
                newDonorInputModel.RhFactor,
                newDonorInputModel.Adress);

            return new CreatedDonorViewModel(createdDonor.Id);
        }

        public async Task Update(int id, UpdateDonorInputModel updateDonorInputModel)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }        
    }
}
