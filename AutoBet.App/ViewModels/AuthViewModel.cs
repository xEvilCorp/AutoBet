using AutoBet.Domain.Interfaces;
using AutoBet.Services;
using System.Windows.Input;

namespace AutoBet.App.ViewModels
{
    public delegate void Notify();

    public class AuthViewModel : BaseViewModel
    {
        #region Properties
        public ICommand LoginCMD { get; set; }
        private IBetfairAuthService BetfairAuthService { get; }
        public event Notify AuthenticationPassed;
        #endregion Properties

        public AuthViewModel() { }
        public AuthViewModel(IBetfairAuthService authService, LanguageService lang)
        {
            L = lang;
            BetfairAuthService = authService;
            LoginCMD = new RelayCommand((o) => Login());
        }


        public void Login()
        {
            L.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            //AuthenticationPassed?.Invoke();
        }

    }
}
