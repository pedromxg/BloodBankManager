using BloodBankManager.Core.Entities.ValueObjects;
using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.InputModels
{
    public class NewDonorInputModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypes BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public Adress Adress { get; private set; }

    }
}
