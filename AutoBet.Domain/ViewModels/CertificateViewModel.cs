using AutoBet.Domain.Entities;
using AutoBet.Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace AutoBet.Domain.ViewModels
{
    public class CertificateViewModel : BaseViewModel
    {
        #region Properties
        private readonly ICertificateService CertificateService;

        public ICommand GenerateCertificateCMD { get; }
        public ICommand SaveCertificateCMD { get; }

        private bool isCertificateValid;
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

        private string name;
        private string email;
        private string organization;
        private string organizationUnit;
        private string country;
        private string state;
        private string city;

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

        #endregion Properties

        public CertificateViewModel() { }
        public CertificateViewModel(ICertificateService certificateService, ILanguageService languageService, IMapper mapper)
        {
            L = languageService; CertificateService = certificateService;
            GenerateCertificateCMD = new RelayCommand(GenerateCertificate);
            SaveCertificateCMD = new RelayCommand(SaveCertificate);
        }

        void GenerateCertificate(object  o)
        {

        }
        void SaveCertificate(object o)
        {

        }

        public void ImportCertificate(string filepath)
        {
            X509Certificate2  cert = CertificateService.GetCertificate(filepath);
            CertificateInfo info = CertificateService.GetInfo(cert.Subject);
            Name = info.CommonName;
            Email = info.Email;
            Organization = info.Organization;
            OrganizationUnit = info.OrganizationalUnitName;
            Country = info.Country;
            IsCertificateValid = !IsCertificateValid;
        }

    }
}
