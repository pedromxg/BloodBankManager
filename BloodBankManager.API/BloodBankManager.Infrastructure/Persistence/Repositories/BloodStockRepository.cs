using BloodBankManager.Core.Entities;
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
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankDbContext _dbContext;

        public BloodStockRepository(BloodBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BloodStock> GetByType(BloodTypes bloodType)
        {
            var bloodStockByType = await _dbContext.BloodStocks.Where(b => b.BloodType == bloodType).FirstOrDefaultAsync();

            return bloodStockByType;
        }

        public async Task CreateAsync(BloodStock newBloodStock)
        {
            _dbContext.BloodStocks.AddAsync(newBloodStock);
        }

        public async Task UpdateAsync(BloodStock updatedBloodStock)
        {
            _dbContext.BloodStocks.UpdateRange(updatedBloodStock);
        }
    }
}
