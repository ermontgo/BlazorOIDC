using System.Threading.Tasks;

namespace BlazorOIDC
{
    public interface IMetadataService
    {
        Task<OpenIdConnectMetadata> FetchMetadataAsync();
    }
}