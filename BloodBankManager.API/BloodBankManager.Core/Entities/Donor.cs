﻿using BloodBankManager.Core.Entities.ValueObjects;
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
        public Donor(string name, string email, DateTime dateOfBirth, string gender, double weight, BloodTypes bloodType, string rhFactor, 
            Adress adress)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Adress = adress;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
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
