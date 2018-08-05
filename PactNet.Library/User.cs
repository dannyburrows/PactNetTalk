using System.Collections.Generic;

namespace PactNet.Library {
  public class User {
    public int Id {get;set;}
    public string Name {get;set;}
    public string Occupation {get;set;}
    public List<Role> Roles {get;set;}
  }

  public class Role {
    public string Name {get;set;}
    public string Description {get;set;}
  }
}