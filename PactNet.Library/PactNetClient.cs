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
      using (var client = new HttpClient { BaseAddress = new Uri(Uri) }) {
        var response = await client.GetAsync($"/api/user/{id}");

        if (response.StatusCode == HttpStatusCode.OK)
          return JsonConvert.DeserializeObject<User> (await response.Content.ReadAsStringAsync ());

        return null;
      }
    }
  }
}