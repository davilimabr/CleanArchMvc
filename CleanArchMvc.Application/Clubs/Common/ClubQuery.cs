using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Clubs.Common
{
    public class ClubQuery : IRequest<IEnumerable<Club>>
    {
    }
}
