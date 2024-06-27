using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class PlayerUnitTest
    {
        [Fact(DisplayName = "Criar jogador com parâmetros válidos")]
        public void CreatePlayer_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => { new Player("Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar jogador com ID válido")]
        public void CreatePlayer_WithValidId_ResultObjectValidState()
        {
            Action action = () => { new Player(1, "Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Erro ao criar jogador com ID inválido")]
        public void CreatePlayer_WithInvalidId_DomainException()
        {
            Action action = () => { new Player(0, "Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O Id deve ser um número positivo.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com nome vazio")]
        public void CreatePlayer_WithEmptyName_DomainException()
        {
            Action action = () => { new Player("", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome não pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com nome muito curto")]
        public void CreatePlayer_WithShortName_DomainException()
        {
            Action action = () => { new Player("Nom", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome inválido.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com nome muito longo")]
        public void CreatePlayer_WithLongName_DomainException()
        {
            Action action = () => { new Player(new string('A', 101), 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome inválido.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com altura negativa")]
        public void CreatePlayer_WithNegativeHeight_DomainException()
        {
            Action action = () => { new Player("Nome valido", -196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Altura deve ser um número positivo.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com posição vazia")]
        public void CreatePlayer_WithEmptyPosition_DomainException()
        {
            Action action = () => { new Player("Nome valido", 196, "", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A posição não pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com posição muito longa")]
        public void CreatePlayer_WithLongPosition_DomainException()
        {
            Action action = () => { new Player("Nome valido", 196, new string('A', 21), DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do campo posição inválido inválido.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com data de nascimento no futuro")]
        public void CreatePlayer_WithFutureDateBirth_DomainException()
        {
            Action action = () => { new Player("Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(1)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data de nascimento não pode ser no futuro.");
        }

        [Fact(DisplayName = "Atualizar jogador com parâmetros válidos")]
        public void UpdatePlayer_WithValidParameters_ResultObjectValidState()
        {
            var player = new Player("Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20));
            Action action = () => { player.UpdatePlayer("Nome atualizado", 198, "Atacante", DateTime.Now.AddYears(-22)); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

    }
}