namespace Domain.Entity;

using Domain.Exceptions;
using Domain.Enum;

public class Patio
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Endereco { get; private set; }
    public string Cidade { get; private set; }
    public double TamanhoMetros { get; private set; }

    private readonly List<Moto> _motos = new();
    public virtual IReadOnlyCollection<Moto> Motos => _motos.AsReadOnly();

    private readonly List<Camera> _cameras = new();
    public virtual IReadOnlyCollection<Camera> Cameras => _cameras.AsReadOnly();

    private Patio(string nome, string endereco, string cidade, double tamanhoMetros)
    {
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

    public void AdicionarNovaMoto(string placa, string modelo, Localizacao loc)
    {
        if (_motos.Count >= 50)
            throw new DomainException("O pátio está lotado.");

        if (_motos.Any(m => m.Placa == placa))
            throw new DomainException("Essa moto já está no pátio.");

        var novaMoto = Moto.Create(placa, modelo, StatusMoto.Ativa, this.Id, loc, null);
        _motos.Add(novaMoto);
    }


    public void InstalarNovaCamera(string nome, string posicao)
    {
        var novaCamera = Camera.Create(nome, posicao, this.Id);
        _cameras.Add(novaCamera);
    }

}