﻿using BloodBankManager.Application.InputModels;
using BloodBankManager.Application.Models.InputModels;
using BloodBankManager.Application.Models.ViewModels;
using BloodBankManager.Application.ViewModels;
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
        Task<DonationDetailsViewModel> GetById(Guid id);
        Task<(bool, CreatedDonationViewModel?)> Create(NewDonationInputModel newDonationInputModel);
        Task Remove(Guid id);
    }
}
