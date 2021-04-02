using System.ComponentModel;
using System.Globalization;

namespace AutoBet.Domain.Interfaces
{
    public interface ILanguageService : INotifyPropertyChanged
    {
        public string this[string input] { get;  }
        public CultureInfo CurrentCulture { get; set; }
    }
}
