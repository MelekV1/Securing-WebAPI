using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTeknolojiCustomAuth.Services
{
    public interface ICustomAuthenticationManager
    {
        string Authenticate(string username, string password);
        IDictionary<string, string> Tokens { get; }
    }

    public class CustomAuthenticationManager : ICustomAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new IDictionary<string, string>
        {
            {"Malek","staj1" },
            {"twitchy","staj2" }
        };

        private readonly IDictionary<string, string> tokens = new IDictionary<string, string>();

        public IDictionary<string, string> tokens => tokens;
        public string Authenticate ( string username , string password)
        {
            if(! users.Any(users => users.Key == username && users.Value == password))
            {
                return null;
            }
            var token = Guid.NewGuid().ToString();
            tokens.Add(token, username);
            return token;
        }
    }
}
