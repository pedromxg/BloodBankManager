using BloodBankManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Models.InputModels
{
    public class NewDonationInputModel
    {
        public DateTime DonationDate { get; set; }
        public double AmountDonated { get; set; }
        public Guid DonorId { get; set; }
    }
}
