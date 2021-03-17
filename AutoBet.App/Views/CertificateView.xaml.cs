using AutoBet.Domain.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace AutoBet.App.Views
{
    /// <summary>
    /// Interaction logic for CertificateView.xaml
    /// </summary>
    public partial class CertificateView : UserControl
    {
        public CertificateView()
        {
            InitializeComponent();
        }

        private void ImportButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Certificate file (*.pfx)|*.pfx";
            bool? result = dialog.ShowDialog();
            var vm = App.Container.GetService<CertificateViewModel>();
            if (result.HasValue && result.Value)
            {
                vm.ImportCertificate(dialog.FileName);
            }
        }
    }
}
