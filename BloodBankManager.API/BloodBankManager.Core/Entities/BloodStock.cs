using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities
{
    public class BloodStock
    {
        public BloodStock(BloodTypes bloodType, string rhFactor, double mlAmount)
        {
            Id = Guid.NewGuid();
            BloodType = bloodType;
            RhFactor = rhFactor;
            MlAmount = mlAmount;
        }

        public Guid Id { get; private set; }
        public BloodTypes BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public double MlAmount { get; private set; }

        public void UpdateAmountInStock(double amountDonated)
        {
            MlAmount += amountDonated;
        }
    }
}
