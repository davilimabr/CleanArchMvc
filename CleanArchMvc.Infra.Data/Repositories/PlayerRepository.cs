using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context) => _context = context;
        public async Task<Player> CreateAsync(Player player)
        {
            _context.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player?> GetByIdAsync(int? id) => await _context.Player.FindAsync(id);

        public async Task<IEnumerable<Player>> GetPlayersAsync() => await _context.Player.ToListAsync();

        public async Task<Player> RemoveAsync(Player player)
        {
            _context.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> UpdateAsync(Player player)
        {
            _context.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
