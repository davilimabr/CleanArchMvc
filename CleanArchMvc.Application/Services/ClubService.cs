using AutoMapper;
using CleanArchMvc.Application.Clubs.Create;
using CleanArchMvc.Application.Clubs.Get;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Extension;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ClubService : IClubService
    {
        private IMediator _mediator;
        private IMapper _mapper;
        private IClubRepository _clubRepository;

        public ClubService(IMediator mediator, IMapper mapper, IClubRepository clubRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clubRepository = clubRepository;
        }

        public async Task<ClubDto> CreateAsync(ClubDto club)
        {
            var clubEntity = _mapper.Map<ClubCreateCommand>(club);
            var result = await _mediator.Send(clubEntity);

            return result is null
                ? throw new Exception("Erro ao criar clube.")
                : _mapper.Map<ClubDto>(result);
        }

        public async Task<ClubDto?> GetByIdAsync(int? id)
        {
            var clubs = await _mediator.Send(new GetClubQuery());

            var club = clubs.Where(x => x.Id == id).FirstOrDefault();

            return club is null
                ? throw new Exception("Recurso não encontrado.")
                : _mapper.Map<ClubDto>(club);
        }

        public async Task<IEnumerable<ClubDto>> GetClubsAsync()
        {
            var clubs = await _mediator.Send(new GetClubQuery());

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
