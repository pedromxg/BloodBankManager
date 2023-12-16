using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Services.Implementations
{
    public class DonorService : IDonorService
    {
        public async Task<List<DonorViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DonorDetailsViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(NewDonorInputModel newDonorInputModel)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateDonorInputModel updateDonorInputModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }        
    }
}
