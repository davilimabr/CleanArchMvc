using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ITrophyRepository
    {
        Task<IEnumerable<Trophy>> GetTrophies();
        Task<IEnumerable<Club>> GetClubFrom(Trophy Trophy);
        Task<Trophy> GetById(int? id);
        Task Create(Trophy Trophy);
        Task Update(Trophy Trophy);
        Task Remove(Trophy Trophy);
    }
}
