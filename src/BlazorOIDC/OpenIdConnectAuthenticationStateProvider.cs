using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public class OpenIdConnectAuthenticationStateProvider : AuthenticationStateProvider
    {
        public NavigationManager UriHelper { get; set; }
        public ITokenProvider TokenProvider { get; set; }

        private AuthenticationState authenticationState;

        public OpenIdConnectAuthenticationStateProvider(NavigationManager uriHelper, ITokenProvider tokenProvider)
        {
            UriHelper = uriHelper;
            TokenProvider = tokenProvider;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!TokenProvider.IsInitialized)
            {
                Uri uri = new Uri(UriHelper.Uri);
                await TokenProvider.InitializeAsync(uri.Fragment);
            }

            if (authenticationState == null && TokenProvider.Token != null)
            {
                JwtClaimsTokenHandler handler = new JwtClaimsTokenHandler();
                var user = handler.ReadUnverifiedIdentityFromToken(TokenProvider.Token);

                authenticationState = new AuthenticationState(user);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return authenticationState;
        }
    }
}
