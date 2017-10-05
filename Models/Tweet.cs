
using System.Collections.Generic;

namespace AG.TweeterApp
{
  public class Tweet : IMessage,IMessageOrder
  {
        public string UserName; // this property is used to map to text file string first
        public User User{get;set;}    
        public string Message{get;set;}    
        public int MessageOrder{get;set;}
  }

}  