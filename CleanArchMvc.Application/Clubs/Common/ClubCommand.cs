using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Clubs.Common
{
    public class ClubCommand : IRequest<Club>
    {
        public string FullName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public int YearFounded { get; set; }
        public string Stadium { get; set; } = string.Empty;
    }
}
