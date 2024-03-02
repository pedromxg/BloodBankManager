using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Models.ViewModels
{
    public class DonationViewModel
    {
        public DonationViewModel(int donorId, 
            double amountDonated, 
            BloodTypes bloodType, 
            DateTime donationDate)
        {
            DonorId = donorId;
            AmountDonated = amountDonated;
            BloodType = bloodType;
            DonationDate = donationDate;
        }

        public int DonorId { get; set; }
        public double AmountDonated { get; set; }
        public BloodTypes BloodType { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
