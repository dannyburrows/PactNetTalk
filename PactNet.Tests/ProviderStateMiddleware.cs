using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Newtonsoft.Json;
using PactNet.Infrastructure.Outputters;
using Xunit.Abstractions;

namespace PactNet.Tests {
  public class XUnitOutput : IOutput {
    private readonly ITestOutputHelper _output;

    public XUnitOutput (ITestOutputHelper output) {
      _output = output;
    }

    public void WriteLine (string line) {
      _output.WriteLine (line);
    }
  }
  public class ProviderState {
    public string Consumer { get; set; }
    public string State { get; set; }
  }
  public class ProviderStateMiddleware {
    private const string ConsumerName = "User API Consumer";
    private readonly RequestDelegate _next;
    private readonly IDictionary<string, Action> _providerStates;
    public ProviderStateMiddleware (RequestDelegate next) {
      _next = next;
      _providerStates = new Dictionary<string, Action> {
        {
        "There is a user for the id",
        AddUser
        }
      };
    }

    private void AddUser () {

    }

    public async Task Invoke (HttpContext context) {
      if (context.Request.Path.Value == "/provider-states") {
        this.HandleProviderStatesRequest (context);
        await context.Response.WriteAsync (String.Empty);
      } else {
        await this._next (context);
      }
    }

    private void HandleProviderStatesRequest (HttpContext context) {
      context.Response.StatusCode = (int) HttpStatusCode.OK;

      if (context.Request.Method.ToUpper () == HttpMethod.Post.ToString ().ToUpper () &&
        context.Request.Body != null) {
        string jsonRequestBody = String.Empty;
        using (var reader = new StreamReader (context.Request.Body, Encoding.UTF8)) {
          jsonRequestBody = reader.ReadToEnd ();
        }

        var providerState = JsonConvert.DeserializeObject<ProviderState> (jsonRequestBody);

        //A null or empty provider state key must be handled
        if (providerState != null && !string.IsNullOrEmpty (providerState.State) &&
          providerState.Consumer == ConsumerName) {
          _providerStates[providerState.State].Invoke ();
        }
      }
    }
  }
}