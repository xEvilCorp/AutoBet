using AutoBet.Domain.Interfaces;

namespace AutoBet.Domain.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(ILanguageService lang)
        {
            L = lang;
        }
    }
}