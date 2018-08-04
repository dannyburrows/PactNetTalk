using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace PactNet.Library {
  public class PactNetClient {
    private string Uri {get;set;}
    private HttpClient Client {get;set;}

    public PactNetClient() {
      Uri = "https://localhost:5001/api";
    }

    public async Task<object> Get() {
      var request = new HttpRequestMessage(HttpMethod.Get, "/user");
      var response = await Client.SendAsync(request);

      if (response.StatusCode == HttpStatusCode.OK)
        return response.Content;
      
      return null;
    }
  }
}