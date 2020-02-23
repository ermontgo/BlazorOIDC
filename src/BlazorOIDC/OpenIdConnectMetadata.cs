namespace BlazorOIDC
{
    public class OpenIdConnectMetadata
    {
        public string Issuer { get; set; }
        public string AuthorizeEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
    }
}