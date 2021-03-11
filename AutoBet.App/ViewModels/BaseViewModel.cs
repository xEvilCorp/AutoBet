using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace AutoBet.App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        internal static Timer SetInterval(Action Act, int Interval)
        {
            Timer tmr = new Timer();
            tmr.Elapsed += (sender, args) => Act();
            tmr.AutoReset = true;
            tmr.Interval = Interval;
            tmr.Start();

            return tmr;
        }
        internal static NavigationService Navigation;

        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(object property)
        {
            string prop = property.GetType().Name;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
