using System.Linq;
using System.Collections.Generic;
using System;

namespace AG.TweeterApp
{
    public static partial class Utils
    {
         public static IList<Tweet> UserTweetsMapper(IDictionary<int,string> tweetDictionary)
         {
            //bug martUserin not Stringfound
                        
            var resultTweetList = new List<Tweet>();
            string delimiter = AppSettings.FileDelimiterTweet;
            int lineNumber = 0;
            var itemString = "";
            foreach(KeyValuePair<int,string> tweetItem in tweetDictionary)
            {
                // find delimiter postion
                lineNumber = tweetItem.Key;
                itemString = tweetItem.Value;
                var chrIdx = itemString.IndexOf(delimiter);     
                if (chrIdx == -1)
                {
                    Logger.LogError("Delimeter for tweets not found in file");
                    continue;
                }
                //extract user name
                string userName = itemString.Substring(0,chrIdx).Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    Logger.LogError("No username in file");
                    continue;
                }                                
                
                //extract the tweets from the rest of the string                
                var strLength = itemString.Length-chrIdx-delimiter.Length-1;                
                string message = itemString.Substring(chrIdx+delimiter.Length+1,strLength);
                if (string.IsNullOrEmpty(message))
                {
                    Logger.LogError("No tweet in file");
                    continue;
                }                                

                //add to tweet object
                var tweet = new Tweet()
                {
                    UserName = userName,
                    Message = message.Trim(),
                    MessageOrder = lineNumber
                };
                
                resultTweetList.Add(tweet);
            }

            return resultTweetList;
        }


    }
}

