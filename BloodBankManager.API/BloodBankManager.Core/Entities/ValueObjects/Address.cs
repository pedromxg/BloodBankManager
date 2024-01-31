using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities.ValueObjects
{
    public class Address
    {
        public Address(string street, string city, string state, string cep)
        {
            Street = street;
            City = city;
            State = state;
            Cep = cep;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Cep { get; private set; }
    }
}
