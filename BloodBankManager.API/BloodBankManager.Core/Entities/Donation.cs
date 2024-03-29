﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities
{
    public class Donation
    {
        public Donation() { }

        public Donation(DateTime donationDate, double amountDonated, Donor donor)
        {
            DonationDate = donationDate;
            AmountDonated = amountDonated;
            Donor = donor;
        }

        public Guid Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public double AmountDonated { get; private set; }
        public Donor Donor { get; private set; }
    }
}
