using System.ComponentModel;

namespace AutoBet.Domain.Interfaces
{
    public interface IPageViewModel : INotifyPropertyChanged
    {
        public string PageTitle { get; set; }
    }
}
