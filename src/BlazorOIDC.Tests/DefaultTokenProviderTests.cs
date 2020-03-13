using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorOIDC;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorOIDC.Tests
{
    [TestClass()]
    public class DefaultTokenProviderTests
    {
        [TestMethod()]
        public async System.Threading.Tasks.Task InitializeAsyncTestAsync()
        {
            var path = "http://localhost:3000#access_token=mah.token&token_type=Bearer&expires_in=3600&scope=lots%20of%20scopes";
            var uri = new Uri(path);

            var provider = new DefaultTokenProvider();
            await provider.InitializeAsync(uri.Fragment);

            Assert.IsTrue(provider.IsInitialized);
            Assert.IsNotNull(provider.Token);
        }
    }
}