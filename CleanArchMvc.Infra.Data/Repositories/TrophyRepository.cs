using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class TrophyRepository : ITrophyRepository
    {
        private readonly ApplicationDbContext _context;
        public TrophyRepository(ApplicationDbContext context) => _context = context;

        public async Task<Trophy> CreateAsync(Trophy trophy)
        {
            _context.Add(trophy);
            await _context.SaveChangesAsync();
            return trophy;
        }

        public async Task<Trophy?> GetByIdAsync(int? id) => await _context.Trophy.FindAsync(id);

        public async Task<IEnumerable<Trophy>> GetTrophiesAsync() => await _context.Trophy.ToListAsync();

        public async Task<Trophy> RemoveAsync(Trophy trophy)
        {
            _context.Remove(trophy);
            await _context.SaveChangesAsync();
            return trophy;
        }

        public async Task<Trophy> UpdateAsync(Trophy trophy)
        {
            _context.Update(trophy);
            await _context.SaveChangesAsync();
            return trophy;
        }
    }
}
