using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using PactNet.Library;
using Newtonsoft.Json;

namespace PactNet.Library {
  public class PactNetClient {
    private string Uri {get;set;}
    private HttpClient Client {get;set;}

    public PactNetClient() {
      Uri = "https://localhost:5001/api";
    }

    public async Task<User> Get(int id) {
      var request = new HttpRequestMessage(HttpMethod.Get, $"/user/{id}");
      var response = await Client.SendAsync(request);

      if (response.StatusCode == HttpStatusCode.OK)
        return JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
      
      return null;
    }
  }
}