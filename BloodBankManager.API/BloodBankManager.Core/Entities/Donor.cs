using BloodBankManager.Core.Entities.ValueObjects;
using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities
{
    public class Donor
    {
        public Donor(int iD, string fullName, string email, DateTime dateOfBirth, string gender, double weight, BloodTypes bloodType, string rhFactor, 
            List<Donation> donations, Adress adress)
        {
            ID = iD;
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Donations = donations;
            Adress = adress;
        }

        public int ID { get; private set; }
        public string FullName { get; private set; }
        public string Email{ get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodTypes BloodType { get; private set; }
        public string RhFactor { get; private set; }
        public List<Donation> Donations { get; private set; }
        public Adress Adress { get; private set; }
    }
}
