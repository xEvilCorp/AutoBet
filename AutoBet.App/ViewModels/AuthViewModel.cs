using AutoBet.Domain.Entities;
using AutoBet.Domain.Enums;
using AutoBet.Domain.Interfaces;
using Microsoft.Extensions.Localization;
using System;
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
        public AuthViewModel(IBetfairAuthService authService, IStringLocalizer<Language.Resources> localizer)
        {
            BetfairAuthService = authService;
            L = localizer;
            LoginCMD = new RelayCommand((o) => Login());
        }


        public void Login()
        {
            string username = L["USERNAME"];
            Language.Resources.Culture = new System.Globalization.CultureInfo("es");
            username = L["USERNAME"];

            //AuthenticationPassed?.Invoke();
        }
    }
}
