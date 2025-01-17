﻿using AutoBet.Domain.Entities;
using FluentValidation;

namespace AutoBet.Domain.Validations
{
    /// <summary>
    /// Validation for the <see cref="CertificateInfo"/> entity class.
    /// </summary>
    public class CertificateInfoValidation : AbstractValidator<CertificateInfo>
    {
        public CertificateInfoValidation()
        {
            const string NO_SPECIAL_CHARS = "^((?![!@#$%^*()~?><&/\\,.\"']).)*$";

            RuleFor(o => o.Country).Length(2).WithMessage("COUNTRY_CODE_CHAR_LENGTH");
            RuleFor(o => o.Email).EmailAddress().WithMessage("EMAIL_MUST_BE_VALID.");
            RuleFor(o => o.Name).Empty().WithMessage("NAME_FIELD_EMPTY");
            RuleFor(o => o.State).Matches(NO_SPECIAL_CHARS).WithMessage("STATE_FIELD_SPECIAL_CHAR");
            RuleFor(o => o.City).Matches(NO_SPECIAL_CHARS).WithMessage("LOCALITY_FIELD_SPECIAL_CHAR");
            RuleFor(o => o.Organization).Matches(NO_SPECIAL_CHARS).WithMessage("ORGANIZATION_FIELD_SPECIAL_CHAR");
            RuleFor(o => o.Name).Matches(NO_SPECIAL_CHARS).WithMessage("NAME_FIELD_SPECIAL_CHAR");
            RuleFor(o => o.OrganizationUnit).Matches(NO_SPECIAL_CHARS).WithMessage("ORGANIZATION_UNIT_FIELD_SPECIAL_CHAR");
        }
    }
}
