using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOIDC
{
    public class OpenIdConnectAuthenticationStateProvider : AuthenticationStateProvider
    {
        [Inject] private NavigationManager UriHelper { get; set; }
        [Inject] private ITokenProvider tokenProvider { get; set; }

        private AuthenticationState authenticationState;

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!tokenProvider.IsInitialized)
            {
                Uri uri = new Uri(UriHelper.Uri);
                await tokenProvider.InitializeAsync(uri.Fragment);
            }

            if (authenticationState == null && tokenProvider.Token != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var user = handler.ValidateToken(tokenProvider.Token, new TokenValidationParameters() { ValidateAudience = false, ValidateIssuer = false, ValidateLifetime = true }, out SecurityToken _);

                authenticationState = new AuthenticationState(user);
            }

            return authenticationState;
        }
    }
}
