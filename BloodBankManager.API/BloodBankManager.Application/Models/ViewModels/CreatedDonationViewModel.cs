using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class CreatedDonationViewModel
    {
        public Guid Id { get; set; }

        public CreatedDonationViewModel() { }

        public CreatedDonationViewModel(Guid id)
        {
            Id = id;
        }
    }
}
