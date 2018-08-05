using System;
using PactNet;
using PactNet.Mocks.MockHttpService;

public class ConsumerApiPact : IDisposable {
  public IPactBuilder PactBuilder { get; private set; }
  public IMockProviderService MockProviderService { get; private set; }

  public int MockServerPort { get { return 9222; } }
  public string MockProviderServiceBaseUri { get { return String.Format ("http://localhost:{0}", MockServerPort); } }

  public ConsumerApiPact () {
    PactBuilder = new PactBuilder (new PactConfig { PactDir = @"..\pacts" });

    PactBuilder
      .ServiceConsumer ("Consumer")
      .HasPactWith ("Something API");

    MockProviderService = PactBuilder.MockService (MockServerPort);
  }

  public void Dispose () {
    PactBuilder.Build (); // builds and saves the pact file
  }
}