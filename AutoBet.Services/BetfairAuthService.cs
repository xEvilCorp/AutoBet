using AutoBet.Domain.Entities;
using AutoBet.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AutoBet.Services
{
    public class BetfairAuthService : IBetfairAuthService
    {
        public HttpClient Client { get; }
        public BetfairAuthService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://identitysso-cert.betfair.com");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("X-Application", "AutoBet");
            
            Client = client; 
        }

        public async Task<LoginResult> Login(User user)
        {
            var values = new Dictionary<string, string>{
                { "username",  user.Name},
                { "password",  user.Password}
            };

            using var body = new FormUrlEncodedContent(values);
            using var response = await Client.PostAsync("/api/certlogin", body);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LoginResult>(jsonResponse);
            }

            return null;
        }

     
    }
}
