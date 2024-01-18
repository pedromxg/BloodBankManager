using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels;

namespace BloodBankManager.Application.Services.Interfaces
{
    public interface IDonorService
    {
        Task<List<DonorViewModel>> GetAll();
        Task<DonorDetailsViewModel> GetById(Guid id);
        Task<CreatedDonorViewModel> Create(NewDonorInputModel newDonorInputModel);
        Task Update(int id, UpdateDonorInputModel updateDonorInputModel);
        Task Remove(int id);
    }
}
