using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Extension;

namespace CleanArchMvc.Application.Services
{
    public class ClubService : IClubService
    {
        private IClubRepository _clubRepository;
        private IMapper _mapper;

        public ClubService(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<ClubDto> CreateAsync(ClubDto club)
        {
            var clubEntity = _mapper.Map<Club>(club);
            var result = await _clubRepository.CreateAsync(clubEntity);

            return result is null
                ? throw new Exception("Erro ao criar clube.")
                : club;
        }

        public async Task<ClubDto?> GetByIdAsync(int? id)
        {
            var clubEntity = await _clubRepository.GetByIdAsync(id!);
            
            return clubEntity is null
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<ClubDto>(clubEntity);
        }

        public async Task<IEnumerable<ClubDto>> GetClubsAsync()
        {
            var clubs = await _clubRepository.GetClubsAsync();

            return clubs.IsNullOrEmpty()
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<IEnumerable<ClubDto>>(clubs);
        }

        public async Task<ClubDto> RemoveAsync(ClubDto club)
        {
            var clubEntity = _mapper.Map<Club>(club);
            var result = await _clubRepository.RemoveAsync(clubEntity);

            return result is null
                ? throw new Exception("Erro ao remover clube.")
                : club;
        }

        public async Task<ClubDto> UpdateAsync(ClubDto club)
        {
            var clubEntity = _mapper.Map<Club>(club);
            var result = await _clubRepository.UpdateAsync(clubEntity);

            return result is null
                ? throw new Exception("Erro ao atualizar clube.")
                : club;
        }
    }
}
