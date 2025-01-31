using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Clubs.Create
{
    public class ClubCreateHandler : IRequestHandler<ClubCreateCommand, Club>
    {
        private IClubRepository _clubRepository;
        private IMapper _mapper;

        public ClubCreateHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<Club> Handle(ClubCreateCommand request, CancellationToken cancellationToken)
        {
            var clubEntity = _mapper.Map<Club>(request);
            return await _clubRepository.CreateAsync(clubEntity);
        }
    }
}
