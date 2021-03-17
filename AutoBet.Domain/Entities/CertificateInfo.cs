using AutoBet.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Domain.Entities
{
    public class CertificateInfo : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Organization { get; private set; }
        public string OrganizationUnit  { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }

        public CertificateInfo(string commonName, string email, string organization, string organizationalUnitName, string country, string state, string locality)
        {
            this.Name = commonName;
            this.Email = email;
            this.Organization = organization;
            this.OrganizationUnit = organizationalUnitName;
            this.Country = country;
            this.State = state;
            this.City = locality;
        }

        public override bool Valid()
        {
            Validation = new CertificateInfoValidation().Validate(this);
            return Validation.IsValid;
        }
    }
}
