using System.IO;
using System.Text.RegularExpressions;
using AuroraTrace.Domain.Enums;
using AuroraTrace.Domain.Exceptions;

namespace AuroraTrace.Domain.Entity
{
    public class Moto
    {
        public Guid Id { get; private set; }
        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public StatusMoto Status { get; private set; }
        public DateTime UltimaAtualizacao { get; private set; }

        public Guid PatioId { get; private set; }
        public virtual Patio Patio { get; private set; }

        public Guid? FuncionarioId { get; private set; }
        public virtual Funcionario? Funcionario { get; private set; }

        public Guid LocalizacaoId { get; private set; }
        public virtual Localizacao Localizacao { get; private set; }

        private Moto(string placa, string modelo, StatusMoto status, Guid patioId, Guid localizacaoId, Guid? funcionarioId)
        {
            ValidarPlaca(placa);

            Id = Guid.NewGuid();
            Placa = placa;
            Modelo = modelo ?? throw new DomainException("Modelo é obrigatório");
            Status = status;
            UltimaAtualizacao = DateTime.UtcNow;
            PatioId = patioId;
            LocalizacaoId = localizacaoId;
            FuncionarioId = funcionarioId;
        }

        private void ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new DomainException("Placa é obrigatória");

            var regex = new Regex(@"^[A-Z]{3}\d{4}$|^[A-Z]{3}[0-9][A-Z][0-9]{2}$", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(placa))
                throw new DomainException($"Placa inválida: {placa}");
        }

        internal static Moto Create(string placa, string modelo, StatusMoto status, Guid patioId, Guid localizacaoId, Guid? funcionarioId)
        {
            return new Moto(placa, modelo, status, patioId, localizacaoId, funcionarioId);
        }

        public Moto() { }
    }
}

