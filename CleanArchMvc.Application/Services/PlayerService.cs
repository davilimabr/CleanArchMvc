using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Extension;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _playerRepository;
        private IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<PlayerDto> CreateAsync(PlayerDto player)
        {
            var playerEntity = _mapper.Map<Player>(player);
            var result = await _playerRepository.CreateAsync(playerEntity);

            return result is null
                ? throw new Exception("Erro ao criar jogador.")
                : player;
        }

        public async Task<PlayerDto?> GetByIdAsync(int? id)
        {
            var playerEntity = await _playerRepository.GetByIdAsync(id);
            return playerEntity is null
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<PlayerDto>(playerEntity);
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
        {
            var players = await _playerRepository.GetPlayersAsync();

            return players.IsNullOrEmpty()
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<IEnumerable<PlayerDto>>(players);
        }

        public async Task<PlayerDto> RemoveAsync(PlayerDto player)
        {
            var playerEntity = _mapper.Map<Player>(player);
            var result = await _playerRepository.RemoveAsync(playerEntity);

            return result is null
                ? throw new Exception("Erro ao remover jogador.")
                : player;
        }

        public async Task<PlayerDto> UpdateAsync(PlayerDto player)
        {
            var playerEntity = _mapper.Map<Player>(player);
            var result = await _playerRepository.UpdateAsync(playerEntity);

            return result is null
                ? throw new Exception("Erro ao atualizar jogador.")
                : player;
        }
    }
}
