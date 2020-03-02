using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public interface ITokenProvider
    {
        string Token { get; }
        bool IsInitialized { get; }
        string ResponseType { get; }

        Task InitializeAsync(string parameters);
    }
}
