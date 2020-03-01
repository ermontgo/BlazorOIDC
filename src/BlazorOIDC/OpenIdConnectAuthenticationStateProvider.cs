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
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var user = handler.ValidateToken(TokenProvider.Token, new TokenValidationParameters() { ValidateAudience = false, ValidateIssuer = false, ValidateLifetime = true }, out SecurityToken _);

                authenticationState = new AuthenticationState(user);
            }
            else
            {
                return new AuthenticationState(ClaimsPrincipal.Current);
            }

            return authenticationState;
        }
    }
}
