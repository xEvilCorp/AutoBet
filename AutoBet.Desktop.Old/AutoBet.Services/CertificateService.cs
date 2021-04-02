using AutoBet.Domain.Entities;
using AutoBet.Domain.Enums;
using AutoBet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace AutoBet.Services
{
    /// <summary>
    /// Certificate service implementation class for creating, updating, reading and interpreting <see cref="X509Certificate2"/> certificates in the Application.
    /// </summary>
    public class CertificateService : ICertificateService
    {
        public X509Certificate2 Create(CertificateInfo c)
        {
            ECDsa key = ECDsa.Create();
            string certificateSubject = $"CN={c.Name};O={c.Organization};OU={c.OrganizationUnit};E={c.Email};C={c.Country};S={c.State};L={c.City}";
            CertificateRequest request = new CertificateRequest(certificateSubject, key, HashAlgorithmName.SHA256);
            X509Certificate2 certificate = request.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(5));
            certificate.FriendlyName = "AutoBetBetfairCertificate";
            return certificate;
        }

        public void AddOrReplaceToStore(X509Certificate2 certificate, AppCertificates id_store)
        {
            X509Store store = new X509Store("AutoBetCertificates", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.RemoveRange(store.Certificates.Find(X509FindType.FindByApplicationPolicy, certificate.FriendlyName, false));
            store.Add(certificate);
        }

        public X509Certificate2 ImportCertificate(string certificate_path)
        {
            X509Certificate2 certificate;
            try
            {
                certificate = new X509Certificate2(certificate_path);
                certificate.FriendlyName = "AutoBetBetfairCertificate";
            }
            catch (Exception) { return null; }

            return certificate;
        }

        public X509Certificate2 GetFromCertificateStore(AppCertificates id_store)
        {
            X509Store store = new X509Store("AutoBetCertificates", StoreLocation.CurrentUser);

            store.Open(OpenFlags.ReadWrite);

            var certificateSearch = store.Certificates.Find(X509FindType.FindByCertificatePolicy, "AutoBetBetfairCertificate", false);

            if (certificateSearch.Count is not 0)
                return certificateSearch[0];

            return null;
        }

        public CertificateInfo DeserializeCertificateSubject(X509Certificate2 certificate)
        {
            string subject = certificate.Subject;
            string[] pairs = subject.Split(',');
            var kvs =new List<KeyValuePair<string, string>>();
            foreach (var pair in pairs)
            {
                string[] separatedPair = pair.Split("=");
                var kv = new KeyValuePair<string, string>(separatedPair[0].ToUpper().Trim(), separatedPair[1]) ;
                kvs.Add(kv);
            }

            CertificateInfo certificateInfo = new CertificateInfo
            (
                commonName: kvs.Find(x => x.Key == "CN").Value,
                email: kvs.Find(x => x.Key == "E").Value,
                organization: kvs.Find(x => x.Key == "O").Value,
                organizationalUnitName: kvs.Find(x => x.Key == "OU").Value,
                country: kvs.Find(x => x.Key == "C").Value,
                state: kvs.Find(x => x.Key == "S").Value,
                locality: kvs.Find(x => x.Key == "L").Value
            );

            return certificateInfo;
        }

        //This is for exporting the certificate into a pfx file in the path specified location.
        //Possibly it should be removed as the feature might not be implemented.
        private void ExportPfx(string path, X509Certificate2 certificate)
        {
            //exports certificate to .pfx.
            File.WriteAllBytes(path, certificate.Export(X509ContentType.Pfx));
            //exports certificate to .cer.
            /*File.WriteAllText(path + ".cer", "-----BEGIN CERTIFICATE-----\r\n"+ Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)+ "\r\n-----END CERTIFICATE-----");*/
        }
    }
}
