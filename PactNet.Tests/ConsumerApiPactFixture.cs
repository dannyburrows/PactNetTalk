using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

public class ConsumerApiPactFixture : IDisposable {
  public IPactBuilder PactBuilder { get; private set; }
  public IMockProviderService MockProviderService { get; private set; }

  public int MockServerPort { get { return 9222; } }
  public string MockProviderServiceBaseUri { get { return String.Format ("http://localhost:{0}", MockServerPort); } }

  public ConsumerApiPactFixture () {
    PactBuilder = new PactBuilder (new PactConfig { 
      SpecificationVersion = "2.0.0"
     });

    PactBuilder
      .ServiceConsumer ("PactNet Consumer")
      .HasPactWith ("PactNet Provider");

    MockProviderService = PactBuilder.MockService(MockServerPort);
  }

  public void Dispose () {
    PactBuilder.Build();
  }
}