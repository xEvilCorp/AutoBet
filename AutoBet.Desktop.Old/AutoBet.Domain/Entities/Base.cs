using FluentValidation.Results;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AutoBet.Domain.Entities
{
    public abstract class Base
    {
        public ValidationResult Validation{ get; protected set; }
        public string[] ErrorMessages => Validation?.Errors?.Select(a => a.ErrorMessage)?.ToArray();

        public abstract bool Valid();
    }
}
