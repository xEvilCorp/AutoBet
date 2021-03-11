using AutoBet.Services;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace AutoBet.App
{
    public partial class MainWindow : Window
    {
        private CertificateService certificateService;
        public MainWindow(CertificateService service)
        {
            InitializeComponent();
            certificateService = service;
        }
    }
}
