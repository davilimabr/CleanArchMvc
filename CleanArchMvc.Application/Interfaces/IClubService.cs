using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IClubService
    {
        Task<IEnumerable<ClubDto>> GetClubsAsync();
        Task<ClubDto?> GetByIdAsync(int? id);
        Task<ClubDto> CreateAsync(ClubDto club);
        Task<ClubDto> UpdateAsync(ClubDto club);
        Task<ClubDto> RemoveAsync(ClubDto club);
    }
}
