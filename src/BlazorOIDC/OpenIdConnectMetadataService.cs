using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace BlazorOIDC
{
    public class OpenIdConnectMetadataService : IMetadataService
    {
        private readonly HttpClient client;
        private readonly OpenIdConnectMetadataConfigurationOptions options;
        private OpenIdConnectMetadata metadata;

        public OpenIdConnectMetadataService(HttpClient client, OpenIdConnectMetadataConfigurationOptions options)
        {
            this.client = client;
            this.options = options;
        }

        public async Task<OpenIdConnectMetadata> FetchMetadataAsync()
        {
            if (metadata == null)
            {
                var disco = await client.GetDiscoveryDocumentAsync(options.MetadataUrl);
                metadata = new OpenIdConnectMetadata() { AuthorizeEndpoint = disco.AuthorizeEndpoint, Issuer = disco.Issuer, TokenEndpoint = disco.TokenEndpoint };
            }

            return metadata;
        }
    }
}