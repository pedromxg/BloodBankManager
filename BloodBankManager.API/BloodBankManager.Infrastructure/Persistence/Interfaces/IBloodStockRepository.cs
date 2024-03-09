using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;

namespace BloodBankManager.Infrastructure.Persistence.Interfaces
{
    public interface IBloodStockRepository
    {
        Task<BloodStock> GetByType(BloodTypes bloodType);
        Task CreateAsync(BloodStock newBloodStock);
        Task UpdateAsync(BloodStock updatedBloodStock);
    }
}
