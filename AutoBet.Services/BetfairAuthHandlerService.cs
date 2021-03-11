using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace AutoBet.Services
{
    public class BetfairAuthHandlerService : HttpClientHandler
    {
        public BetfairAuthHandlerService()
        {
            ClientCertificateOptions = ClientCertificateOption.Manual;
            SslProtocols = SslProtocols.Tls12;
            ClientCertificates.Add(GetCertificate());
        }

        private X509Certificate2 GetCertificate()
        {
            string root = AppContext.BaseDirectory;
            string filepath = "certificate.pfx";
            string fullpath = root + filepath;
            return new X509Certificate2(fullpath);
        }

    }
}
