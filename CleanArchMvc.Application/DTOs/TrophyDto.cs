namespace CleanArchMvc.Application.DTOs
{
    public class TrophyDto
    {
        public int Id { get; set; }
        public string Competition { get; set; } = string.Empty;
        public int Year { get; set; }
        public ClubDto? Club { get; set; }
    }
}
