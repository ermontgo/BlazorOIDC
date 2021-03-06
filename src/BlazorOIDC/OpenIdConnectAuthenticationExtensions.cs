﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorOIDC
{
    public static class OpenIdConnectAuthenticationExtensions
    {
        public static IServiceCollection UseOpenIdConnectAuthentication(this IServiceCollection services, string oidcServer, string clientId, string redirectPath, params string[] scopes)
        {
            var options = new OpenIdConnectMetadataConfigurationOptions($"{oidcServer}/.well-known/openid-configuration", clientId, redirectPath, scopes);
            services.AddSingleton(options);

            services.AddSingleton<IMetadataService, OpenIdConnectMetadataService>();
            services.AddSingleton<ITokenProvider, DefaultTokenProvider>();
            services.AddSingleton<OpenIdConnectRedirectProvider>();
            services.AddScoped<AuthenticationStateProvider, OpenIdConnectAuthenticationStateProvider>();

            return services;
        }
    }
}
