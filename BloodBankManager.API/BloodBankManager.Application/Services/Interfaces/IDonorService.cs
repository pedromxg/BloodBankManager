using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels;

namespace BloodBankManager.Application.Services.Interfaces
{
    public interface IDonorService
    {
        Task<List<DonorViewModel>> GetAll();
        Task<DonorDetailsViewModel> GetById(Guid id);
        Task<(bool, CreatedDonorViewModel?)> Create(NewDonorInputModel newDonorInputModel);
        Task<bool> Update(Guid id, UpdateDonorInputModel updateDonorInputModel);
        Task Remove(Guid id);
    }
}
