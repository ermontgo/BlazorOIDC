using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorOIDC
{
    internal class JwtClaimsTokenHandler : JwtSecurityTokenHandler
    {
        public JwtClaimsTokenHandler()
        {
            InboundClaimTypeMap = new Dictionary<string, string>();
            OutboundClaimTypeMap = new Dictionary<string, string>();
        }

        public ClaimsPrincipal ReadUnverifiedIdentityFromToken(string token, TokenValidationParameters parameters = null)
        {
            parameters = parameters ?? new Microsoft.IdentityModel.Tokens.TokenValidationParameters() { ValidateAudience = false, ValidateIssuer = false };
            var jwt = ReadJwtToken(token);
            return ValidateTokenPayload(jwt, parameters);
        }
    }
}
