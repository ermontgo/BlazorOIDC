using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorOIDC
{
    public class OpenIdConnectMetadataConfigurationOptions
    {
        public OpenIdConnectMetadataConfigurationOptions(string metadataUrl, string clientId, string redirectPath, params string[] scopes)
        {
            MetadataUrl = metadataUrl;
            ClientId = clientId;
            RedirectPath = redirectPath;
            Scopes = scopes;
        }

        public string MetadataUrl { get; set; }
        public string ClientId { get; set; }
        public string[] Scopes { get; }
        public string RedirectPath { get; set; }
    }
}
