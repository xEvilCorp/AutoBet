using AutoBet.Domain.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AutoBet.App.ViewModels
{
    public class MainViewModel 
    {
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

        public MainViewModel(AuthViewModel authViewModel)
        {
            this.Pages = new ObservableCollection<IPageViewModel>()  { authViewModel  };
            this.SelectedPage = this.Pages.First();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
