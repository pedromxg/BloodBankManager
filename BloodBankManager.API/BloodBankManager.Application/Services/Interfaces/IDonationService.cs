using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Services.Interfaces
{
    public interface IDonationService
    {
        Task<List<DonationViewModel>> GetAll();
        Task<CreatedDonationViewModel> Create(NewDonationViewModel newDonation);
    }
}
