using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Entities.ValueObjects;
using BloodBankManager.Core.Enums;
using BloodBankManager.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankDbContext _dbContext;
        public DonorRepository(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Donor> Create(string name, string email, DateTime dateOfBirth, string gender, double weight, BloodTypes bloodType, string rhFactor,
            Adress adress)
        {
            var donor = new Donor(name, email, dateOfBirth, gender, weight, bloodType, rhFactor, adress);

            _dbContext.Donors.Add(donor);

            return donor;
        }

        public async Task<List<Donor>> GetAll()
        {
            var donors = _dbContext.Donors.ToListAsync();

            return await donors;
        }

        public async Task<Donor> GetById(Guid id)
        {
            return _dbContext.Donors.FirstOrDefault(d => d.Id == id);
        }
    }
}
