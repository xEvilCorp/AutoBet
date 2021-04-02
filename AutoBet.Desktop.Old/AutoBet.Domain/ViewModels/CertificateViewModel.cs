using AutoBet.Domain.Entities;
using AutoBet.Domain.Enums;
using AutoBet.Domain.Interfaces;
using AutoMapper;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace AutoBet.Domain.ViewModels
{
    public class CertificateViewModel : BaseViewModel
    {
        #region Properties
        private readonly ICertificateService certificateService;
        private readonly IMapper mapper;

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
        public CertificateViewModel(ICertificateService certService, ILanguageService langService, IMapper mapService)
        {
            L = langService; certificateService = certService; mapper = mapService;
            GenerateCertificateCMD = new RelayCommand(GenerateCertificate);
            SaveCertificateCMD = new RelayCommand(SaveCertificate);

            InitializeInfo();
        }

        void InitializeInfo()
        {
            X509Certificate2 cert = certificateService.GetFromCertificateStore(AppCertificates.BetfairNonInteractiveAuthCertificate);
            if (cert != null)
            {
                IsCertificateValid = true;
                CertificateInfo info = certificateService.DeserializeCertificateSubject(cert);
                mapper.Map(info, this);
            }
        }

        void GenerateCertificate(object o)
        {

        }
        void SaveCertificate(object o)
        {

        }

        public void ImportCertificate(string filepath)
        {
            X509Certificate2 certificate = certificateService.ImportCertificate(filepath);
            if(certificate is not null)
            {
                CertificateInfo info = certificateService.DeserializeCertificateSubject(certificate);
                certificateService.AddOrReplaceToStore(certificate, AppCertificates.BetfairNonInteractiveAuthCertificate);
                mapper.Map(info, this);
                IsCertificateValid = true;
            }
        }

    }
}
