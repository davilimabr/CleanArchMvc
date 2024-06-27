using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
        Task<IEnumerable<Club>> GetClubFromAsync(Player player);
        Task<Player> GetByIdAsync(int? id);
        Task CreateAsync(Player player);
        Task UpdateAsync(Player player);
        Task RemoveAsync(Player player);
    }
}
