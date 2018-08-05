using System.Collections.Generic;
using Newtonsoft.Json;

namespace PactNet.Library {
  public class User {
    [JsonProperty(PropertyName = "id")]
    public int Id {get;set;}
    
    [JsonProperty(PropertyName = "name")]
    public string Name {get;set;}
    
    [JsonProperty(PropertyName = "occupation")]
    public string Occupation {get;set;}
    
    [JsonProperty(PropertyName = "roles")]
    public List<Role> Roles {get;set;}
  }

  public class Role {
    [JsonProperty(PropertyName = "name")]
    public string Name {get;set;}

    [JsonProperty(PropertyName = "description")]
    public string Description {get;set;}
  }
}