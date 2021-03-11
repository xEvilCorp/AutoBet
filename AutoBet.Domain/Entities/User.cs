using AutoBet.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoBet.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public override bool Valid()
        {
            Validation = new UserValidation().Validate(this);
            return Validation.IsValid;
        }
    }
}
