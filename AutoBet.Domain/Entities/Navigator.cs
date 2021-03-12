using AutoBet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Domain.Entities
{
    class Navigator : INavigator
    {
        private INavigable Navigable { get; }

        public Navigator(INavigable navigable) => this.Navigable = navigable;

        public bool TrySelect(string title) => this.Navigable.TrySelect(title);
    }
}
