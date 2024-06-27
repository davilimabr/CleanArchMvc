using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ClubUnitTest
    {
        [Fact(DisplayName = "Criar clube com parâmetros válidos")]
        public void CreateClub_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => { new Club("Clube de Futebol", "CF", 1900, "Estádio Nacional"); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Erro ao criar clube com nome completo vazio")]
        public void CreateClub_WithEmptyFullName_DomainException()
        {
            Action action = () => { new Club("", "CF", 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome completo não pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome completo muito curto")]
        public void CreateClub_WithShortFullName_DomainException()
        {
            Action action = () => { new Club("CF", "CF", 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome completo inválido.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome completo muito longo")]
        public void CreateClub_WithLongFullName_DomainException()
        {
            Action action = () => { new Club(new string('A', 101), "CF", 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome completo inválido.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome curto vazio")]
        public void CreateClub_WithEmptyShortName_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "", 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O nome curto não pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome curto muito curto")]
        public void CreateClub_WithShortShortName_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "C", 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome curto inválido.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome curto muito longo")]
        public void CreateClub_WithLongShortName_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", new string('A', 21), 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome curto inválido.");
        }

        [Fact(DisplayName = "Erro ao criar clube com ano de fundação negativo")]
        public void CreateClub_WithNegativeYearFounded_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "CF", -1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Ano inválido.");
        }

        [Fact(DisplayName = "Erro ao criar clube com ano de fundação no futuro")]
        public void CreateClub_WithFutureYearFounded_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "CF", DateTime.Now.Year + 1, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O ano de fundação não pode estar no futuro.");
        }

        [Fact(DisplayName = "Erro ao criar clube com estádio vazio")]
        public void CreateClub_WithEmptyStadium_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "CF", 1900, ""); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O estádio não pode ser vazio.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome do estádio muito curto")]
        public void CreateClub_WithShortStadiumName_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "CF", 1900, "Est"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome do estádio inválido.");
        }

        [Fact(DisplayName = "Erro ao criar clube com nome do estádio muito longo")]
        public void CreateClub_WithLongStadiumName_DomainException()
        {
            Action action = () => { new Club("Clube de Futebol", "CF", 1900, new string('A', 101)); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Tamanho do nome do estádio inválido.");
        }

        [Fact(DisplayName = "Criar clube com ID válido")]
        public void CreateClub_WithValidId_ResultObjectValidState()
        {
            Action action = () => { new Club(1, "Clube de Futebol", "CF", 1900, "Estádio Nacional"); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Erro ao criar clube com ID inválido")]
        public void CreateClub_WithInvalidId_DomainException()
        {
            Action action = () => { new Club(0, "Clube de Futebol", "CF", 1900, "Estádio Nacional"); };
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O Id deve ser um número positivo.");
        }

        [Fact(DisplayName = "Atualizar clube com parâmetros válidos")]
        public void UpdateClub_WithValidParameters_ResultObjectValidState()
        {
            var club = new Club("Clube de Futebol", "CF", 1900, "Estádio Nacional");
            Action action = () => { club.Update("Clube Atualizado", "CA", 1901, "Estádio Atualizado"); };
            action.Should().NotThrow<DomainExceptionValidation>();
        }
    }
}
