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
            var tokenProvider = new MockTokenProvider() { Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyLCJleHAiOjE4MTYyMzkwMjJ9.DYTQuvkWQ3CJi34H7pvb21dtcnVZPbTzIRJLXZO_UIg" };
            var uriHelper = new MockNavigationManager();
            uriHelper.SetUri("http://www.yahoo.com/", "http://www.yahoo.com/");

            var provider = new OpenIdConnectAuthenticationStateProvider(uriHelper, tokenProvider);

            var user = await provider.GetAuthenticationStateAsync();

            Assert.IsNotNull(user);
            Assert.IsTrue(user.User.Identity.IsAuthenticated);
            Assert.AreEqual("1234567890", user.User.FindFirst("sub").Value);
        }
    }

    public class MockTokenProvider : ITokenProvider
    {
        public string Token { get; set; }
        public bool IsInitialized { get; set; }

        public string ResponseType => "mock_token";

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