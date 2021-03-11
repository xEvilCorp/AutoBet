using AutoBet.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace AutoBet.Domain.Interfaces
{
    public interface ICertificateService
    {
        public X509Certificate2 Create(CertificateInfo c);
        public void AddOrReplace(X509Certificate2 certificate);
        public X509Certificate2 GetBetfairCertificate();
    }
}
