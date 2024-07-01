using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetClubsAsync();
        Task<Club?> GetByIdAsync(int? id);
        Task<Club> CreateAsync(Club club);
        Task<Club> UpdateAsync(Club club);
        Task<Club> RemoveAsync(Club club);
    }
}
