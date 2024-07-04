using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ITrophyService
    {
        Task<IEnumerable<TrophyDto>> GetTrophiesAsync();
        Task<TrophyDto?> GetByIdAsync(int? id);
        Task<TrophyDto> CreateAsync(TrophyDto trophy);
        Task<TrophyDto> UpdateAsync(TrophyDto trophy);
        Task<TrophyDto> RemoveAsync(TrophyDto trophy);
    }
}
