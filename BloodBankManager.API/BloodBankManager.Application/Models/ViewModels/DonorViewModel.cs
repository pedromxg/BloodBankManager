using BloodBankManager.Core.Entities.ValueObjects;
using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.ViewModels
{
    public class DonorViewModel
    {
        public DonorViewModel(string name,BloodTypes bloodType, string rhFactor)
        {
            Name = name;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public string Name { get; private set; }
        public BloodTypes BloodType { get; private set; }
        public string RhFactor { get; private set; }
    }
}
