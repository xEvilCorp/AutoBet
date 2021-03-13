using AutoBet.Domain.Enums;
using AutoBet.Domain.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AutoBet.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties
        private IPageViewModel selectedPage;
        public IPageViewModel SelectedPage
        {
            get => this.selectedPage;
            set
            {
                if (object.Equals(value, this.selectedPage))
                {
                    return;
                }

                this.selectedPage = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IPageViewModel> pages;
        public ObservableCollection<IPageViewModel> Pages
        {
            get => this.pages;
            set
            {
                if (object.Equals(value, this.pages))
                {
                    return;
                }

                this.pages = value;
                OnPropertyChanged();
            }
        }
        #endregion Properties

        public MainViewModel(AuthViewModel authVM, HomeViewModel homeVM)
        {
            this.Pages = new ObservableCollection<IPageViewModel>()  { authVM, homeVM };
            this.SelectedPage = this.Pages.First();
            authVM.AuthenticationPassed += () => Navigate(AppPages.Home);
        }

        public void Navigate(AppPages page)
        {
            SelectedPage = Pages[(int)page];
        }


    }
}
