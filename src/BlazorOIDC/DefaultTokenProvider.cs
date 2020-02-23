using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public class DefaultTokenProvider : ITokenProvider
    {
        public string Token { get; set; }
        public bool IsInitialized { get; set; }

        public async Task InitializeAsync(string parameters)
        {
            var fragmentParameters = BuildParameters(parameters);
            if (fragmentParameters.ContainsKey("id_token"))
            {
                Token = fragmentParameters["id_token"];
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
