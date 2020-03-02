using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public class DefaultTokenProvider : ITokenProvider
    {
        public string Token { get; protected set; }
        public bool IsInitialized { get; protected set; }
        public string ResponseType => "token";

        public async Task InitializeAsync(string parameters)
        {
            var fragmentParameters = BuildParameters(parameters);
            if (fragmentParameters.ContainsKey(ResponseType))
            {
                Token = fragmentParameters[ResponseType];
            }

            IsInitialized = true;
        }

        private Dictionary<string, string> BuildParameters(string query)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            var kvps = query.Split('&');
            foreach (var kvp in kvps)
            {
                var components = kvp.Split('=');
                if (components.Count() > 1)
                {
                    result.Add(components[0], components[1]);
                }
            }

            return result;
        }
    }
}
