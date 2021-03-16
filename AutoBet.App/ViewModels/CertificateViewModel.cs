using AutoBet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoBet.App.ViewModels
{
    public class CertificateViewModel : BaseViewModel
    {
        #region Properties
        public ICommand ImportCertificateCMD { get; }
        public ICommand GenerateCertificateCMD { get; }
        public ICommand SaveCertificateCMD { get; }

        private string name;
        private string email;
        private string organization;
        private string organizationUnit;
        private string country;
        private string state;
        private string city;
        private bool isCertificateValid;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                OnPropertyChanged();
            }
        }
        public string Organization
        {
            get
            {
                return this.organization;
            }

            set
            {
                this.organization = value;
                OnPropertyChanged();
            }
        }
        public string OrganizationUnit
        {
            get
            {
                return this.organizationUnit;
            }

            set
            {
                this.organizationUnit = value;
                OnPropertyChanged();
            }
        }
        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                this.country = value;
                OnPropertyChanged();
            }
        }
        public string State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
                OnPropertyChanged();
            }
        }

        public bool IsCertificateValid
        {
            get
            {
                return this.isCertificateValid;
            }

            set
            {
                this.isCertificateValid = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
        public CertificateViewModel() { }
        public CertificateViewModel(LanguageService lang)
        {
            L = lang;
            GenerateCertificateCMD = new RelayCommand(GenerateCertificate);
            SaveCertificateCMD = new RelayCommand(SaveCertificate);
            ImportCertificateCMD = new RelayCommand(ImportCertificate);
        }

        void GenerateCertificate(object  o)
        {

        }
        void SaveCertificate(object o)
        {

        }
        void ImportCertificate(object o)
        {
            IsCertificateValid = !IsCertificateValid;
        }

    }
}
