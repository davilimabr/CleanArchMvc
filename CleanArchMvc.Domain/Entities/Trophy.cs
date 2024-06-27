using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Trophy
    {
        public int Id { get; private set; }
        public string Competition { get; private set; }
        public int Year { get; private set; }

        public int ClubId { get; private set; }
        public Club Club { get; private set; }

        public Trophy(string competition, int year)
        {
            ValidadeDomain(competition, year);
            Update(competition, year);
        }

        public Trophy(int id, string competition, int year)
        {
            DomainExceptionValidation.When(id <= 0, "O Id deve ser um número positivo.");
            Id = id;

            ValidadeDomain(competition, year);
            Update(competition, year);
        }

        private static void ValidadeDomain(string competition, int year)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(competition), "Campo competição não pode ser vazio.");
            DomainExceptionValidation.When(competition.Length < 4 || competition.Length > 100, "Tamanho campo competição inválido.");

            DomainExceptionValidation.When(year < 0, "Ano inválido.");
            DomainExceptionValidation.When(year > DateTime.Now.Year, "O ano do troféu não pode estar no futuro.");
        }

        public void Update(string competition, int year, int clubId)
        {
            Update(competition, year);
            ClubId = clubId;
        }

        public void Update(string competition, int year)
        {
            Competition = competition;
            Year = year;
        }
    }
}
