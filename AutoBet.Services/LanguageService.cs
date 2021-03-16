using AutoBet.Domain.Interfaces;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace AutoBet.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ResourceManager ResourceManager;

        private CultureInfo currentCulture;
        public CultureInfo CurrentCulture
        {
            get
            {
                return currentCulture;
            }
            set
            {
                if (this.currentCulture != value)
                {
                    this.currentCulture = value;
                    OnCultureChanged();
                }
            }
        }

        public string this[string input]
        {
            get
            {
                if(input.Contains('@'))
                {
                    var v = input.Split('@');
                    var (key, fontcase) = (v[0], v[1]);
                    var text = Translate(key);
                    switch (fontcase)
                    {
                        case "Upper": return text.ToUpperInvariant();
                        case "Lower": return text.ToLowerInvariant();
                        default: return text;
                    }
                }
                else return Translate(input);
            }
        }

        private string Translate(string key)
        {
            return ResourceManager.GetString(key.ToUpperInvariant(), CurrentCulture);
        }

        public LanguageService()
        {
            ResourceManager = Language.Resources.ResourceManager;
            CurrentCulture = new CultureInfo("pt-BR");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnCultureChanged()
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
