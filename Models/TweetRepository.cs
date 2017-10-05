using System;
using System.Linq;
using System.Collections.Generic;

namespace AG.TweeterApp
{
    public class TweetRepository : ITweetRepository
    {
        private IList<Tweet> Tweets;        

        public TweetRepository(IList<Tweet> tweets = null)
        {
            if (tweets == null)
            {
                //if no users then load it from default file
                var tweetStrings = FileManager.ReadTweetsFromFile();
                if(tweetStrings == null || tweetStrings.Count() == 0)
                {
                    Logger.LogError("Error reading strings from tweet file");                    
                }
                else
                {
                    Tweets = Utils.UserTweetsMapper(tweetStrings);                
                }
            }
            else
            {
                Tweets = tweets;
            }

            //need a better way of doing this and removing dependancy
            IUserRepository existingUsers = new UserRepository();

            bool hasExistingUsers = !(existingUsers is null);
            //create new collection of users based on tweets
           
           
                //add user object that exists in user collection to tweets.user where matched
            foreach(var tweet in Tweets)
            {
                // if has user naem
                if (!string.IsNullOrEmpty(tweet.UserName))
                {                    
                    if (hasExistingUsers)
                    {
                        var existingUser = existingUsers.GetByName(tweet.UserName);
                        if (!(existingUser is null))
                        {
                            tweet.User = existingUser;
                        }
                    }
                    if (tweet.User is null)                                                            
                    {
                        tweet.User = new User(){Name = tweet.UserName};
                    }
                }

            }            
            
        }

       
        public IList<Tweet> GetAllTweets()
        {            
            return Tweets;
        }

        public IList<Tweet> GetTweetsByUserName(string userName)
        {               
            return Tweets.Where(x=>x.User.Name == userName).ToList();            
            //return Tweets.Where(x=>x.User.Name == userName || x.User.Following.Any(y=>y.Name == userName)).ToList();
        }


    }
}