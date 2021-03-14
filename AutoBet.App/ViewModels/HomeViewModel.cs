using AutoBet.Services;

namespace AutoBet.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(LanguageService lang)
        {
            L = lang;
        }
    }
}