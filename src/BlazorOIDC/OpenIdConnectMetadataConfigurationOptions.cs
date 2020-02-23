using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorOIDC
{
    public class OpenIdConnectMetadataConfigurationOptions
    {
        public OpenIdConnectMetadataConfigurationOptions(string metadataUrl, string clientId, params string[] scopes)
        {
            MetadataUrl = metadataUrl;
            ClientId = clientId;
            Scopes = scopes;
        }

        public string MetadataUrl { get; set; }
        public string ClientId { get; set; }
        public string[] Scopes { get; }
    }
}
