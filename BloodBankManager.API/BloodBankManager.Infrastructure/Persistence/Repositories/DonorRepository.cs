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
            Address adress)
        {
            var donor = new Donor(name, email, dateOfBirth, gender, weight, bloodType, rhFactor, adress);

            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();

            return donor;
        }

        public async Task<List<Donor>> GetAll()
        {
            return await _dbContext.Donors.ToListAsync();
        }

        public async Task<Donor> GetById(Guid id)
        {
            return await _dbContext.Donors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Update(Donor updatedDonor)
        {
            _dbContext.Donors.UpdateRange(updatedDonor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(Donor donor)
        {
            _dbContext.Donors.Remove(donor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
