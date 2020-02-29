﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorOIDC
{
    public static class OpenIdConnectAuthenticationExtensions
    {
        public static IServiceCollection UseOpenIdConnectAuthentication(this IServiceCollection services, string oidcServer, string clientId, params string[] scopes)
        {
            var options = new OpenIdConnectMetadataConfigurationOptions($"{oidcServer}/.well-known/openid-configuration", clientId, scopes);
            services.AddSingleton(options);

            services.AddSingleton<IMetadataService, OpenIdConnectMetadataService>();
            services.AddSingleton<OpenIdConnectRedirectProvider>();
            services.AddSingleton<ITokenProvider, DefaultTokenProvider>();
            services.AddScoped<AuthenticationStateProvider, OpenIdConnectAuthenticationStateProvider>();

            return services;
        }
    }
}
