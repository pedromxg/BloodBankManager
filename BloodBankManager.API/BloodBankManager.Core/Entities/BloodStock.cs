using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities
{
    public class BloodStock
    {
        public BloodStock(int iD, string bloodType, string rhFactor, int mlAmount)
        {
            ID = iD;
            BloodType = bloodType;
            RhFactor = rhFactor;
            MlAmount = mlAmount;
        }

        public int ID { get; private set; }
        public string BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public int MlAmount { get; private set; }
    }
}
