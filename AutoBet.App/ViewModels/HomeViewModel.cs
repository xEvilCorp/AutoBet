using AutoBet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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