using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.ValueObjects
{
    public class Password
    {
        public string Value { get; private set; }

        private Password() { }

        public Password(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("La contraseña no puede estar vacía");

            if (valor.Length < 8)
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres");

            if (!valor.Any(char.IsUpper))
                throw new ArgumentException("La contraseña debe tener al menos una letra mayúscula");

            if (!valor.Any(char.IsLower))
                throw new ArgumentException("La contraseña debe tener al menos una letra minúscula");

            if (!valor.Any(char.IsDigit))
                throw new ArgumentException("La contraseña debe tener al menos un número");

            Value = valor;
        }
    }
}
