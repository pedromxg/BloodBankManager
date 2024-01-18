using BloodBankManager.Core.Entities.ValueObjects;
using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Infrastructure.Persistence.Interfaces
{
    public interface IDonorRepository
    {
        Task<Donor> Create(string name, string email, DateTime dateOfBirth, string gender, double weight, BloodTypes bloodType, string rhFactor,
            Adress adress);

        Task<List<Donor>> GetAll();

        Task<Donor> GetById(Guid id);
    }
}
