using BloodBankManager.Core.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.InputModels
{
    public class UpdateDonorInputModel
    {
        public Address Adress { get; private set; }
    }
}
