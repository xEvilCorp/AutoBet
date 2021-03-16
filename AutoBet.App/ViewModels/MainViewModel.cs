using AutoBet.Domain.Enums;
using AutoBet.Domain.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

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

        public MainViewModel(AuthViewModel authVM, HomeViewModel homeVM, CertificateViewModel certVM)
        {
            this.Pages = new ObservableCollection<IPageViewModel>()  { authVM, homeVM, certVM };
            this.SelectedPage = this.Pages.First();
            authVM.AuthenticationPassed += () => Navigate(AppPages.Home);
            authVM.EditCertificateClicked += () => Navigate(AppPages.ManageCertificate);
        }

        public void Navigate(AppPages page)
        {
            SelectedPage = Pages[(int)page];
        }
    }
}
