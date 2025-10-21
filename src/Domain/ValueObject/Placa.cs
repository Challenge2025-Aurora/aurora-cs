using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class Placa : IEquatable<Placa>
    {
        public string Valor { get; }

        public Placa(string valor)
        {
            if (!Regex.IsMatch(valor, @"^[A-Z]{3}[0-9][0-9A-Z][0-9]{2}$"))
                throw new ArgumentException("Placa inválida.");

            Valor = valor.ToUpper();
        }

        public override bool Equals(object? obj) => Equals(obj as Placa);

        public bool Equals(Placa? other) => other != null && Valor == other.Valor;

        public override string ToString() => Valor;
    }

}
