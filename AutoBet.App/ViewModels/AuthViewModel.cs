using AutoBet.Domain.Entities;
using AutoBet.Domain.Enums;
using AutoBet.Domain.Interfaces;
using System;
using System.Windows.Input;

namespace AutoBet.App.ViewModels
{
    public delegate void Notify();  // delegate

    public class AuthViewModel : BaseViewModel
    {
        #region Properties
        public ICommand LoginCMD { get; set; }
        private IBetfairAuthService BetfairAuthService { get; }
        public event Notify AuthenticationPassed;
        #endregion Properties

        public AuthViewModel() {}
        public AuthViewModel(IBetfairAuthService authService) 
        {
            BetfairAuthService = authService;
            LoginCMD = new RelayCommand((o) => Login());
        }


        public void Login()
        {
            AuthenticationPassed?.Invoke();
        }
    }
}
