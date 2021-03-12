using AutoBet.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBet.Services
{
    public class MainNavigationService
    {
        public object Content { get; set; }
        public IPageViewModel CurrentPage { get; set; }

        public void Update()
        {
            Content = CurrentPage;
        }
    }
}
