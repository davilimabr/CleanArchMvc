using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetClubsAsync();
        Task<IEnumerable<Player>> GetPlayersOfAsync(Club club);
        Task<IEnumerable<Trophy>> GetTrophiesOfAsync(Club club);
        Task<Club> GetByIdAsync(int? id);
        Task CreateAsync(Club club);
        Task UpdateAsync(Club club);
        Task RemoveAsync(Club club);
    }
}
