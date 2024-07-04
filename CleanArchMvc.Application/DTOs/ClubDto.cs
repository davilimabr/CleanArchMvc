namespace CleanArchMvc.Application.DTOs
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public int YearFounded { get; set; }
        public string Stadium { get; set; } = string.Empty;
        public IEnumerable<TrophyDto>? Tropies { get; set; }
        public IEnumerable<PlayerDto>? Players { get; set; }
    }
}
