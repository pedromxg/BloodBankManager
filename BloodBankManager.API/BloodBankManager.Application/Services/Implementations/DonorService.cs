using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Application.ViewModels;
using BloodBankManager.Infrastructure.Persistence.Interfaces;

namespace BloodBankManager.Application.Services.Implementations
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

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

            if (donor == null)
            {
                return new DonorDetailsViewModel();
            }

            return new DonorDetailsViewModel(donor.Name, donor.Email, donor.DateOfBirth, donor.Gender, donor.Weight, donor.BloodType,
                donor.RhFactor, donor.Address);
        }

        public async Task<(bool, CreatedDonorViewModel?)> Create(NewDonorInputModel newDonorInputModel)
        {
            var registeredDonors = _donorRepository.GetAll().Result;

            var canCreateDonor = !registeredDonors.Exists(r => r.Email.Equals(newDonorInputModel.Email));

            if (!canCreateDonor)
                return (canCreateDonor, null);

            var createdDonor = await _donorRepository.Create(newDonorInputModel.Name,
                newDonorInputModel.Email,
                newDonorInputModel.DateOfBirth,
                newDonorInputModel.Gender,
                newDonorInputModel.Weight,
                newDonorInputModel.BloodType,
                newDonorInputModel.RhFactor,
                newDonorInputModel.Address);

            return (canCreateDonor, new CreatedDonorViewModel(createdDonor.Id));
        }

        public async Task<bool> Update(Guid id, UpdateDonorInputModel updateDonorInputModel)
        {
            var donor = _donorRepository.GetById(id).Result;

            if (donor == null)
                return false;

            donor.UpdateAddress(updateDonorInputModel.Adress);

            await _donorRepository.Update(donor);

            return true;
        }

        public async Task Remove(Guid id)
        {
            var donor = await _donorRepository.GetById(id);

            await _donorRepository.Remove(donor);
        }        
    }
}
