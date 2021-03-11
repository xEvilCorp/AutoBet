using AutoBet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Domain.Interfaces
{
    public interface IBetfairAuthService
    {
        Task<LoginResult> Login(User user);
    }
}
