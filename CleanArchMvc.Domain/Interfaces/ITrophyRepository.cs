using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ITrophyRepository
    {
        Task<IEnumerable<Trophy>> GetTrophiesAsync();
        Task<Trophy?> GetByIdAsync(int? id);
        Task<Trophy> CreateAsync(Trophy trophy);
        Task<Trophy> UpdateAsync(Trophy trophy);
        Task<Trophy> RemoveAsync(Trophy trophy);
    }
}
