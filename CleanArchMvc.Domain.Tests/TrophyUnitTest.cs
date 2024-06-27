using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class TrophyUnitTest
    {
        [Fact(DisplayName = "Criar troféu com parâmetros válidos")]
        public void CreateTrophy_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => { new Trophy("Campeonato Brasileiro", 2023); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Erro ao criar troféu com nome da competição vazio")]
        public void CreateTrophy_WithEmptyCompetition_DomainException()
        {
            Action action = () => { new Trophy("", 2023); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Campo competição não pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar troféu com nome da competição muito curto")]
        public void CreateTrophy_WithShortCompetitionName_DomainException()
        {
            Action action = () => { new Trophy("Cup", 2023); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho campo competição inválido.");
        }

        [Fact(DisplayName = "Erro ao criar troféu com nome da competição muito longo")]
        public void CreateTrophy_WithLongCompetitionName_DomainException()
        {
            Action action = () => { new Trophy(new string('A', 101), 2023); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho campo competição inválido.");
        }

        [Fact(DisplayName = "Erro ao criar troféu com ano negativo")]
        public void CreateTrophy_WithNegativeYear_DomainException()
        {
            Action action = () => { new Trophy("Campeonato Brasileiro", -2023); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Ano inválido.");
        }

        [Fact(DisplayName = "Erro ao criar troféu com ano no futuro")]
        public void CreateTrophy_WithFutureYear_DomainException()
        {
            Action action = () => { new Trophy("Campeonato Brasileiro", DateTime.Now.Year + 1); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O ano do troféu não pode estar no futuro.");
        }

        [Fact(DisplayName = "Criar troféu com ID válido")]
        public void CreateTrophy_WithValidId_ResultObjectValidState()
        {
            Action action = () => { new Trophy(1, "Campeonato Brasileiro", 2023); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Erro ao criar troféu com ID inválido")]
        public void CreateTrophy_WithInvalidId_DomainException()
        {
            Action action = () => { new Trophy(0, "Campeonato Brasileiro", 2023); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O Id deve ser um número positivo.");
        }

        [Fact(DisplayName = "Atualizar troféu com parâmetros válidos")]
        public void UpdateTrophy_WithValidParameters_ResultObjectValidState()
        {
            var trophy = new Trophy("Campeonato Brasileiro", 2023);
            Action action = () => { trophy.Update("Copa do Brasil", 2022); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}
