using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public interface ITokenProvider
    {
        string Token { get; set; }
        bool IsInitialized { get; set; }

        Task InitializeAsync(string parameters);
    }
}
