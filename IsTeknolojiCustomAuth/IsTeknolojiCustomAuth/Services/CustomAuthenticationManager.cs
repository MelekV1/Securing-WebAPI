using IsTeknolojiCustomAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTeknolojiCustomAuth.Services
{
    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "Malek", "staj1" },
            { "Hamza", "staj2" }
        };
        private readonly IDictionary<string, string> tokens = new Dictionary<string, string>();
        public IDictionary<string, string> Tokens => tokens;
        
        public string Authenticate(string username, string password)
        {
            if(!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }
            var token = Guid.NewGuid().ToString();
            tokens.Add(token, username);
            return token;
        }

    }
}
