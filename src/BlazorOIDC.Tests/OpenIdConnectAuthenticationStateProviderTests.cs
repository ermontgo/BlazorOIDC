using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorOIDC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorOIDC.Tests
{
    [TestClass()]
    public class OpenIdConnectAuthenticationStateProviderTests
    {
        [TestMethod()]
        public async Task GetAuthenticationStateAsyncTestAsync()
        {
            var tokenProvider = new MockTokenProvider();
            var uriHelper = new MockNavigationManager();
            uriHelper.SetUri("http://www.yahoo.com/", "http://www.yahoo.com/");

            var provider = new OpenIdConnectAuthenticationStateProvider()
            {
                UriHelper = uriHelper,
                TokenProvider = tokenProvider
            };

            await provider.GetAuthenticationStateAsync();
        }
    }

    public class MockTokenProvider : ITokenProvider
    {
        public string Token { get; set; }
        public bool IsInitialized { get; set; }

        public async Task InitializeAsync(string parameters)
        {
            
        }
    }

    public class MockNavigationManager : NavigationManager
    {
        
        public void SetUri(string baseUri, string uri)
        {
            this.Initialize(baseUri, uri);
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            
            throw new NotImplementedException();
        }
    }
}