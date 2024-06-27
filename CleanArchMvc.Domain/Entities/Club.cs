

using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Club : Entity
    {
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public int YearFounded { get; private set; }
        public string Stadium { get; private set; }

        public ICollection<Trophy> Tropies { get; private set; }
        public ICollection<Player> Players { get; private set; }

        public Club(string fullName, string shortName, int yearFounded, string Stadium)
        {
            ValidadeDomain(fullName, shortName, yearFounded, Stadium);
            Update(fullName, shortName, yearFounded, Stadium);
        }

        public Club(int id, string fullName, string shortName, int yearFounded, string Stadium)
        {
            DomainExceptionValidation.When(id <= 0, "O Id deve ser um número positivo.");
            Id = id;

            ValidadeDomain(fullName, shortName, yearFounded, Stadium);
            Update(fullName, shortName, yearFounded, Stadium);
        }

        private static void ValidadeDomain(string fullName, string shortName, int yearFounded, string Stadium)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(fullName), "O nome completo não pode ser vazio.");
            DomainExceptionValidation.When(fullName.Length < 4 || fullName.Length > 100, "Tamanho do nome completo inválido.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(shortName), "O nome curto não pode ser vazio.");
            DomainExceptionValidation.When(fullName.Length < 2 || fullName.Length > 20, "Tamanho do nome curto inválido.");

            DomainExceptionValidation.When(yearFounded < 0, "Ano inválido.");
            DomainExceptionValidation.When(yearFounded > DateTime.Now.Year, "O ano de fundação não pode estar no futuro.");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Stadium), "O estádio não pode ser vazio.");
            DomainExceptionValidation.When(fullName.Length < 4 || fullName.Length > 100, "Tamanho do nome do estádio inválido.");
        }

        public void Update(string fullName, string shortName, int yearFounded, string stadium)
        {
            FullName = fullName;
            ShortName = shortName;
            YearFounded = yearFounded;
            Stadium = stadium;
        }
    }
}
