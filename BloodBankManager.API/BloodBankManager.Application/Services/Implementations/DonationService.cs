using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.Services.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Interfaces;
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

        public Task<(bool, CreatedDonationViewModel?)> Create(NewDonationInputModel newDonationInputModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<DonationViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DonationDetailsViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
