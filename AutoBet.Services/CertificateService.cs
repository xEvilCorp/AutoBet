using AutoBet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Services
{
    public class CertificateService
    {
        public X509Certificate2 Create(CertificateInfo c)
        {
            ECDsa key = ECDsa.Create();
            string certificateSubject = $"CN={c.CommonName};O={c.Organization};OU={c.OrganizationalUnitName};E={c.Email};C={c.Country};S={c.State};L={c.Locality}";
            CertificateRequest request = new CertificateRequest(certificateSubject, key, HashAlgorithmName.SHA256);
            X509Certificate2 certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));
            return certificate;
        }

        public void AddOrReplace(X509Certificate2 certificate)
        {
            X509Store store = new X509Store("ugabogus", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.RemoveRange(store.Certificates);
            store.Add(certificate);
        }

        public X509Certificate2 GetBetfairCertificate()
        {
            X509Store store = new X509Store("ugabogus", StoreLocation.CurrentUser);
            store.Open(OpenFlags.OpenExistingOnly);
            return store.Certificates[0];
        }

        public void ExportPfx(string path, X509Certificate2 certificate)
        {
            File.WriteAllBytes(path, certificate.Export(X509ContentType.Pfx));
            /*File.WriteAllText(path + ".cer", "-----BEGIN CERTIFICATE-----\r\n"+ Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)+ "\r\n-----END CERTIFICATE-----");*/
        }
    }
}
