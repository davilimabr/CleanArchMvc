using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class PlayerUnitTest
    {
        [Fact(DisplayName = "Criar jogador com par�metros v�lidos")]
        public void CreatePlayer_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => { new Player("Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar jogador com ID v�lido")]
        public void CreatePlayer_WithValidId_ResultObjectValidState()
        {
            Action action = () => { new Player(1, "Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Erro ao criar jogador com ID inv�lido")]
        public void CreatePlayer_WithInvalidId_DomainException()
        {
            Action action = () => { new Player(0, "Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O Id deve ser um n�mero positivo.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com nome vazio")]
        public void CreatePlayer_WithEmptyName_DomainException()
        {
            Action action = () => { new Player("", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome n�o pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com nome muito curto")]
        public void CreatePlayer_WithShortName_DomainException()
        {
            Action action = () => { new Player("Nom", 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome inv�lido.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com nome muito longo")]
        public void CreatePlayer_WithLongName_DomainException()
        {
            Action action = () => { new Player(new string('A', 101), 196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome inv�lido.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com altura negativa")]
        public void CreatePlayer_WithNegativeHeight_DomainException()
        {
            Action action = () => { new Player("Nome valido", -196, "Zagueiro", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Altura deve ser um n�mero positivo.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com posi��o vazia")]
        public void CreatePlayer_WithEmptyPosition_DomainException()
        {
            Action action = () => { new Player("Nome valido", 196, "", DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A posi��o n�o pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com posi��o muito longa")]
        public void CreatePlayer_WithLongPosition_DomainException()
        {
            Action action = () => { new Player("Nome valido", 196, new string('A', 21), DateTime.Now.AddYears(-20)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do campo posi��o inv�lido inv�lido.");
        }

        [Fact(DisplayName = "Erro ao criar jogador com data de nascimento no futuro")]
        public void CreatePlayer_WithFutureDateBirth_DomainException()
        {
            Action action = () => { new Player("Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(1)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data de nascimento n�o pode ser no futuro.");
        }

        [Fact(DisplayName = "Atualizar jogador com par�metros v�lidos")]
        public void UpdatePlayer_WithValidParameters_ResultObjectValidState()
        {
            var player = new Player("Nome valido", 196, "Zagueiro", DateTime.Now.AddYears(-20));
            Action action = () => { player.UpdatePlayer("Nome atualizado", 198, "Atacante", DateTime.Now.AddYears(-22)); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

    }
}