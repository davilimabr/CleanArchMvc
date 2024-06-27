using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Player : Entity
    {
        public string FullName { get; private set; }
        public int Height { get; private set; }
        public string Position { get; private set; }
        public DateTime DateBirth { get; private set; }

        public int ClubId { get; private set; }
        public Club Club { get; private set; }

        public Player(string fullName, int height, string position, DateTime datebirth)
        {
            ValidadeDomain(fullName, height, position, datebirth);
        }

        public Player(int id, string fullName, int height, string position, DateTime datebirth)
        {
            DomainExceptionValidation.When(id <= 0, "O Id deve ser um número positivo.");
            Id = id;

            ValidadeDomain(fullName, height, position, datebirth);
        }

        private static void ValidadeDomain(string fullName, decimal height, string position, DateTime datebirth)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(fullName), "O nome não pode ser vazio.");
            DomainExceptionValidation.When(fullName.Length < 4 || fullName.Length > 100, "Tamanho do nome inválido.");
            DomainExceptionValidation.When(height <= 0, "Altura deve ser um número positivo.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(position), "A posição não pode ser vazio.");
            DomainExceptionValidation.When(position.Length > 20, "Tamanho do campo posição inválido inválido.");
            DomainExceptionValidation.When(datebirth >= DateTime.Now, "Data de nascimento não pode ser no futuro.");
        }

        public void UpdatePlayer(string fullName, int height, string position, DateTime datebirth, int clubId)
        {
            UpdatePlayer(fullName, height, position, datebirth);
            ClubId = clubId;
        }

        public void UpdatePlayer(string fullName, int height, string position, DateTime datebirth)
        {
            FullName = fullName;
            Height = height;
            Position = position;
            DateBirth = datebirth;
        }
    }
}
