using AuroraTrace.Domain.Exceptions;

namespace AuroraTrace.Domain.Entity
{
    public class Patio
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public double TamanhoMetros { get; private set; }

        private Patio(string nome, string endereco, string cidade, double tamanhoMetros)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new DomainException("Nome é obrigatório");
            Endereco = endereco ?? throw new DomainException("Endereço é obrigatório");
            Cidade = cidade ?? throw new DomainException("Cidade é obrigatória");
            TamanhoMetros = tamanhoMetros;
        }

        internal static Patio Create(string nome, string endereco, string cidade, double tamanhoMetros)
        {
            return new Patio(nome, endereco, cidade, tamanhoMetros);
        }

        public Patio() { }
    }
}
