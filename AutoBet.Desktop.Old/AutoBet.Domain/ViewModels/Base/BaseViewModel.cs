using AutoBet.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace AutoBet.Domain.ViewModels
{
    public abstract class BaseViewModel : IPageViewModel
    {
        #region Common Properties
        public string PageTitle { get; set; }
        private ILanguageService languageService;
        public ILanguageService L
        {
            get
            {
                return languageService;
            }
            set
            {
                languageService = value;
                OnPropertyChanged();
            }
        }
        #endregion Common Properties

        internal static Timer SetInterval(Action Act, int Interval)
        {
            Timer tmr = new Timer();
            tmr.Elapsed += (sender, args) => Act();
            tmr.AutoReset = true;
            tmr.Interval = Interval;
            tmr.Start();

            return tmr;
        }

        #region Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Interface implementation
    }
}
