using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Entities.ValueObjects;
using BloodBankManager.Core.Enums;
using BloodBankManager.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodBankManager.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankDbContext _dbContext;

        public DonationRepository(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Donation> Create(DateTime donationDate, double amountDonated, Donor donor)
        {
            var donation = new Donation(donationDate, amountDonated, donor);

            await _dbContext.Donations.AddAsync(donation);

            await _dbContext.SaveChangesAsync();

            return donation;
        }

        public async Task<List<Donation>> GetAll()
        {
            return await _dbContext.Donations.ToListAsync();
        }

        public async Task<List<Donation>> GetAllFromReferenceDate(DateTime referenceDate)
        {
            var donations = await _dbContext.Donations
                .Where(d => d.DonationDate >= referenceDate)
                .ToListAsync();

            return donations;
        }

        public async Task<Donation> GetById(Guid id)
        {
            return await _dbContext.Donations.FirstOrDefaultAsync(d => d.Id.Equals(id));
        }

        public async Task Remove(Donation donation)
        {
            _dbContext.Donations.Remove(donation);

            await _dbContext.SaveChangesAsync();
        }
    }
}
