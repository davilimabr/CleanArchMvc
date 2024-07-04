using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetPlayersAsync();
        Task<PlayerDto?> GetByIdAsync(int? id);
        Task<PlayerDto> CreateAsync(PlayerDto player);
        Task<PlayerDto> UpdateAsync(PlayerDto player);
        Task<PlayerDto> RemoveAsync(PlayerDto player);
    }
}
