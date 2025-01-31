using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Extension;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Clubs.Get
{
    public class GetClubHandler : IRequestHandler<GetClubQuery, IEnumerable<Club>>
    {
        private IClubRepository _clubRepository;
        private IMapper _mapper;

        public GetClubHandler(IClubRepository clubRepository, IMapper mapper)
        {
            _clubRepository = clubRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Club>> Handle(GetClubQuery request, CancellationToken cancellationToken)
        {
            var clubs = await _clubRepository.GetClubsAsync();

            return clubs.IsNullOrEmpty()
                ? throw new Exception("Recurso não encontrado.")
                : clubs;
        }
    }
}
