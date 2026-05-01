using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.ValueObjects
{
    public class Username
    {
        public string Value { get; }

        public Username(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("\r\nEl nombre no puede estar vacío.");

            if (value.Length < 2)
                throw new Exception("\r\nEl nombre es demasiado corto.");

            Value = value.Trim();
        }
    }
}
