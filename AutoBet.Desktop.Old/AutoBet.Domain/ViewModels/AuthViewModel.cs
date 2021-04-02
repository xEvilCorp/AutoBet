using AutoBet.Domain.Interfaces;
using System.Windows.Input;

namespace AutoBet.Domain.ViewModels
{
    public delegate void Notify();

    public class AuthViewModel : BaseViewModel
    {
        #region Properties
        public ICommand LoginCMD { get; set; }
        public ICommand EditCertificateCMD { get; set; }

        private IBetfairAuthService BetfairAuthService { get; }
        public event Notify AuthenticationPassed;
        public event Notify EditCertificateClicked;
        #endregion Properties

        public AuthViewModel() { }
        public AuthViewModel(IBetfairAuthService authService, ILanguageService lang)
        {
            L = lang;
            BetfairAuthService = authService;
            LoginCMD = new RelayCommand((o) => Login());
            EditCertificateCMD = new RelayCommand((o) => EditCertificateClicked?.Invoke());
        }

        public void Login()
        {
            AuthenticationPassed?.Invoke();
        }

    }
}
