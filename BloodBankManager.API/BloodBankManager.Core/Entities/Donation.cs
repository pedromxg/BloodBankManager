using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities
{
    public class Donation
    {
        public Donation(int iD, int donorId, DateTime donatinoDate, int amountDonated, Donor donor)
        {
            ID = iD;
            DonorId = donorId;
            DonatinoDate = donatinoDate;
            AmountDonated = amountDonated;
            Donor = donor;
        }

        public int ID { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonatinoDate { get; private set; }
        public int AmountDonated { get; private set; }
        public Donor Donor { get; private set; }
    }
}
