using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
        Task<Player?> GetByIdAsync(int? id);
        Task<Player> CreateAsync(Player player);
        Task<Player> UpdateAsync(Player player);
        Task<Player> RemoveAsync(Player player);
    }
}
