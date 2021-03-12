using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Domain.Interfaces
{
    public interface INavigable
    {
        bool TrySelect(string title);
    }
}
