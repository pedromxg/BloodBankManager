using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Core.Entities.ValueObjects
{
    public class Address
    {
        public Address(string street,
        string city,
        string state,
        string cep) => (Street, City, State, Cep) = (street, city, state, cep);

        public string Street { get;  }
        public string City { get; }
        public string State { get; }
        public string Cep { get; }
    }
}
