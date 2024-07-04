namespace CleanArchMvc.Application.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Height { get; set; }
        public string Position { get; set; } = string.Empty;
        public DateOnly DateBirth { get; set; } 
        public ClubDto? Club { get; set; } 
    }
}
