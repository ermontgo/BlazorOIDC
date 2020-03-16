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
        private readonly ITokenProvider tokenProvider;

        public OpenIdConnectRedirectProvider(IMetadataService metadataService, NavigationManager navigationManager, OpenIdConnectMetadataConfigurationOptions options, ITokenProvider tokenProvider)
        {
            this.metadataService = metadataService;
            this.navigationManager = navigationManager;
            this.options = options;
            this.tokenProvider = tokenProvider;
        }

        public async Task RedirectAsync()
        {
            var metadata = await metadataService.FetchMetadataAsync();
            var path = Uri.EscapeUriString(navigationManager.BaseUri + options.RedirectPath);
            navigationManager.NavigateTo($"{metadata.AuthorizeEndpoint}?client_id={options.ClientId}&redirect_uri={path}&scope={Uri.EscapeUriString(string.Join(" ", options.Scopes))}&response_type={Uri.EscapeUriString(tokenProvider.ResponseType)}&prompt=login");
        }

        public bool IsUserInitialized => tokenProvider.IsInitialized;
    }
}
