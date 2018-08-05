using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit;
using Xunit.Abstractions;

namespace PactNet.Tests {
    public class PactNetProducerTests {
        private IWebHost _webHost;
        private ITestOutputHelper _output;
        private string _providerUrl = "http://localhost:5000";
        private string _serviceUrl = "http://localhost:9923";
        public PactNetProducerTests (ITestOutputHelper output) {
            _output = output;
            _webHost = WebHost.CreateDefaultBuilder ()
                .UseUrls (_serviceUrl)
                .UseStartup<MockOwinStartup> ()
                .Build ();
            _webHost.Start ();
        }

        [Fact]
        public void EnsureApiHonorsPact () {
            var config = new PactVerifierConfig {
                Outputters = new List<IOutput> {
                new XUnitOutput (_output)
                },
                Verbose = true
            };

            IPactVerifier verifier = new PactVerifier (config);
            verifier.ProviderState ($"{_serviceUrl}/provider-states")
                .ServiceProvider ("PactNet Provider", _providerUrl)
                .HonoursPactWith ("PactNet Consumer")
                .PactUri (@"..\..\..\pacts\pactnet_consumer-pactnet_provider.json")
                .Verify ();
        }
    }
}