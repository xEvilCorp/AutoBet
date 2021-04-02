using AutoBet.Domain.Entities;
using AutoBet.Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace AutoBet.Domain.Interfaces
{
    /// <summary>
    /// Certificate service interface for creating, updating, reading and interpreting <see cref="X509Certificate2"/> certificates in the Application.
    /// </summary>
    public interface ICertificateService
    {
        /// <summary>
        /// Expects a <see cref="CertificateInfo"/> object.
        /// <para>It creates a <see cref="X509Certificate2"/> with the <see cref="CertificateInfo"/> serialized as a string into the certificate Subject.</para>
        /// <para>The certificate contains a public and private key, but no password.</para>
        /// <para>It does not save or adds the certificate to any location, it simply creates the object.</para>
        /// </summary>
        /// <returns>A <see cref="X509Certificate2"/> object.</returns>
        public X509Certificate2 Create(CertificateInfo certificateInfo);

        /// <summary>
        /// Expects a <see cref="X509Certificate2"/> certificate object and a <see cref="AppCertificates"/> enum value representing the store of choice.
        /// <para>It adds the certificate to the system local certificate store specified by the enum</para>
        /// <para>If the certificate already exists in the store it then replaces it.</para>
        /// </summary>
        public void AddOrReplaceToStore(X509Certificate2 certificate, AppCertificates store);

        /// <summary>
        /// Expects a value from the <see cref="AppCertificates"/> enum representing the specific certificate store to import the certificate from.
        /// <para> The certificate is imported from the system certificate store specified by the enum. </para>
        /// </summary>
        /// <returns>
        /// A <see cref="X509Certificate2"/> if the certificate was found in the store. Returns <see cref="null"/> if not.
        /// </returns>
        public X509Certificate2 GetFromCertificateStore(AppCertificates store);

        /// <summary>
        /// Expects a <see cref="string"/> containing the path to a certificate file ie. pfx files.
        /// </summary>
        /// <returns>A <see cref="X509Certificate2"/> object based on the file if it was found and <see cref="null"/> if not.</returns>
        public X509Certificate2 ImportCertificate(string path);

        /// <summary>
        /// Expects a <see cref="X509Certificate2"/> certificate object. 
        /// <br>It deserializes the certificate subject string into a <see cref="CertificateInfo"/> object. </br>
        /// <para>The certificate subject string format expected is:<br>E=email, CN=name, O=organization...</br></para>
        /// </summary>
        /// <returns>A <see cref="CertificateInfo"/> object containing the deserialized data.</returns>
        public CertificateInfo DeserializeCertificateSubject(X509Certificate2 certificate);
    }
}
