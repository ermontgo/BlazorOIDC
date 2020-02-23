using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public class OpenIdConnectRedirectProvider : IOpenIdConnectRedirectProvider
    {
        private readonly IMetadataService metadataService;
        private readonly NavigationManager navigationManager;
        private readonly OpenIdConnectMetadataConfigurationOptions options;

        public OpenIdConnectRedirectProvider(IMetadataService metadataService, NavigationManager navigationManager, OpenIdConnectMetadataConfigurationOptions options)
        {
            this.metadataService = metadataService;
            this.navigationManager = navigationManager;
            this.options = options;
        }

        public async Task RedirectAsync()
        {
            var metadata = await metadataService.FetchMetadataAsync();
            var path = navigationManager.BaseUri;
            navigationManager.NavigateTo($"{metadata.AuthorizeEndpoint}?client_id={options.ClientId}&redirect_uri={path}&scope={string.Join(" ", options.Scopes)}&response_type=id_token&prompt=login");
        }
    }
}
