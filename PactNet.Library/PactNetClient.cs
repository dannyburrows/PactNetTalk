using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PactNet.Library;

namespace PactNet.Library {
  public class PactNetClient {
    private string Uri { get; set; }

    public PactNetClient (string uri) {
      Uri = uri;
    }

    public async Task<User> Get (int id) {
      ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
      using (var client = new HttpClient { BaseAddress = new Uri(Uri) }) {
        var request = new HttpRequestMessage (HttpMethod.Get, $"/api/user/{id}");
        request.Headers.Add("Accept", "application/json");

        var response = await client.SendAsync (request);

        if (response.StatusCode == HttpStatusCode.OK)
          return JsonConvert.DeserializeObject<User> (await response.Content.ReadAsStringAsync ());

        return null;
      }
    }
  }
}