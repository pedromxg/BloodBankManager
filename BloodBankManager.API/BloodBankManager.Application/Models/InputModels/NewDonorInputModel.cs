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
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public BloodTypes BloodType { get; set; }
        public string RhFactor { get; set; }
        public Address Address { get; set; }

    }
}
