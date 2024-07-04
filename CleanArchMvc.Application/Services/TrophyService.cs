using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Extension;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class TrophyService : ITrophyService
    {
        private ITrophyRepository _trophyRepository;
        private IMapper _mapper;

        public TrophyService(ITrophyRepository trophyRepository, IMapper mapper)
        {
            _trophyRepository = trophyRepository;
            _mapper = mapper;
        }

        public async Task<TrophyDto> CreateAsync(TrophyDto trophy)
        {
            var trophyEntity = _mapper.Map<Trophy>(trophy);
            var result = await _trophyRepository.CreateAsync(trophyEntity);

            return result is null
                ? throw new Exception("Erro ao criar troféu.")
                : _mapper.Map<TrophyDto>(result);
        }

        public async Task<TrophyDto?> GetByIdAsync(int? id)
        {
            var result = await _trophyRepository.GetByIdAsync(id);

            return result is null
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<TrophyDto>(result);
        }

        public async Task<IEnumerable<TrophyDto>> GetTrophiesAsync()
        {
            var trophies = await _trophyRepository.GetTrophiesAsync();

            return trophies.IsNullOrEmpty()
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<IEnumerable<TrophyDto>>(trophies);
        }

        public async Task<TrophyDto> RemoveAsync(TrophyDto trophy)
        {
            var trophyEntity = _mapper.Map<Trophy>(trophy);
            var result = await _trophyRepository.RemoveAsync(trophyEntity);

            return result is null
                ? throw new Exception("Erro ao remover troféu.")
                : _mapper.Map<TrophyDto>(result);
        }

        public async Task<TrophyDto> UpdateAsync(TrophyDto trophy)
        {
            var trophyEntity = _mapper.Map<Trophy>(trophy);
            var result = await _trophyRepository.UpdateAsync(trophyEntity);

            return result is null
                ? throw new Exception("Erro ao atualizar troféu.")
                : _mapper.Map<TrophyDto>(result);
        }
    }
}
