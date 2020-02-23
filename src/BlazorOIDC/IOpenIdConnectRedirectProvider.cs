using System.Threading.Tasks;

namespace BlazorOIDC
{
    public interface IOpenIdConnectRedirectProvider
    {
        Task RedirectAsync();
    }
}