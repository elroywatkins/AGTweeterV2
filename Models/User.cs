
using System.Collections.Generic;

namespace AG.TweeterApp
{
  public class User : IPerson
  {
        public string Name{get;set;}
        public IList<Follower> Following {get;set;}
  }

}  