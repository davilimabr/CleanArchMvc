using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;
        public ClubRepository(ApplicationDbContext context) => _context = context;
        public async Task<Club> CreateAsync(Club club)
        {
            _context.Add(club);
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<Club?> GetByIdAsync(int? id) => await _context.Club.FindAsync(id);

        public async Task<IEnumerable<Club>> GetClubsAsync() => await _context.Club.ToListAsync();

        public async Task<Club> RemoveAsync(Club club)
        {
            _context.Remove(club);
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<Club> UpdateAsync(Club club)
        {
            _context.Update(club);
            await _context.SaveChangesAsync();
            return club;
        }
    }
}
