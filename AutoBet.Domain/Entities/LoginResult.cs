using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Domain.Entities
{
    public class LoginResult
    {
        public string SessionToken { get; set; }
        public string LoginStatus { get; set; }       
    }
}
