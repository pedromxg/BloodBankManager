using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Services.Interfaces
{
    public interface IDonorService
    {
        Task<List<DonorViewModel>> GetAll();
        Task<DonorDetailsViewModel> GetById(int id);
        Task<int> Create(NewDonorInputModel newDonorInputModel);
        void Update(UpdateDonorInputModel updateDonorInputModel);
        void Delete(int id);
    }
}
